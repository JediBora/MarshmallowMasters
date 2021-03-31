using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GunPotatoStates : MonoBehaviour
{
    #region Variables
    public enum GPStates
    {
        UNSET,
        SPAWN,
        CHASE,
        PLANT,
        UPROOT,
        ATTACK
    };

    public GPStates currentState;

    private IEnumerator raycastCoroutine;
    private IEnumerator attackCoroutine;

    private ObjectPooler objectPool;

    private GameObject target;
    private GameObject gun;
    private GameObject bulletPrefab;
    private GunPotato gunPotatoStateMachine;

    [SerializeField] private NavMeshAgent agent;

    private float interpolator;
    public float attackTime;

    private bool attackCoroutineStarted;
    #endregion

    /// <summary>
    /// Called when script enabled. Resets all variables to their default states
    /// so that AI works properly.
    /// </summary>
    private void OnEnable()
    {
        raycastCoroutine = DrawRayToTarget(2f);
        attackCoroutine = AttackTarget(attackTime);
        StartCoroutine(raycastCoroutine);

        agent = GetComponent<NavMeshAgent>();
        attackCoroutineStarted = false;
        objectPool = GameObject.Find("ObjectPooler").GetComponent<ObjectPooler>();
        bulletPrefab = Resources.Load("GunPotatoBullet") as GameObject;
    }

    /// <summary>
    /// Performs proper cleanup to ensure object is disabled properly.
    /// </summary>
    private void OnDisable()
    {
        StopCoroutine(raycastCoroutine);
        if (gun != null)
        {
            gun.transform.position = new Vector3(gun.transform.position.x, 0.68f, gun.transform.position.z);
        }
    }

    private void Start() //Sets target and gets components
    {
        gunPotatoStateMachine = GetComponent<GunPotato>();
        target = gunPotatoStateMachine.target;
        gun = gameObject.transform.GetChild(0).gameObject;
    }

    /// <summary>
    /// Spawn state. Enemy rises from the ground
    /// </summary>
    public void Spawn()
    {
        agent.baseOffset += 1 * Time.deltaTime;
        if (agent.baseOffset >= 0.6f)
        {
            ChangeState(GPStates.CHASE);
            Debug.Log("State changed to CHASE");
        }
    }

    /// <summary>
    /// Called after Spawn or Uproot behaviours. Simply moves agent to target position,
    /// or closest position on navmesh.
    /// </summary>
    public void Chase(GameObject target)
    {
        agent.SetDestination(SetChasePosition(target.transform.position));
    }

    /// <summary>
    /// Called when target within line of sight. Agent plants itself into the ground
    /// and readies it's gun.
    /// </summary>
    public void Plant()
    {
        agent.baseOffset = Mathf.Lerp(0.6f, 0f, interpolator);
        gun.transform.position = new Vector3(gun.transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y + 1.25f, interpolator), gun.transform.position.z);
        interpolator += 1 * Time.deltaTime;
        if(agent.baseOffset <= 0f)
        {
            agent.baseOffset = 0f;
            ChangeState(GPStates.ATTACK);
            Debug.Log("State changed to ATTACK");
        }
    }

    /// <summary>
    /// Called when raycast does not meet target. Agent uproots itself, hides
    /// it's gun, and resumes chasing.
    /// </summary>
    public void Uproot()
    {
        agent.baseOffset = Mathf.Lerp(0f, 0.6f, interpolator);
        gun.transform.position = new Vector3(gun.transform.position.x, Mathf.Lerp(gun.transform.position.y, 0.68f, interpolator), gun.transform.position.z);
        interpolator += 1 * Time.deltaTime;
        if (agent.baseOffset >= 0.6f)
        {
            agent.baseOffset = 0.6f;
            ChangeState(GPStates.CHASE);
            Debug.Log("State changed to CHASE");
        }
    }

    /// <summary>
    /// Called when agent can see target and is planted. Fires projectiles at target
    /// </summary>
    public void Attack()
    {
        if (!attackCoroutineStarted)
        {
            StartCoroutine(attackCoroutine);
            attackCoroutineStarted = true;
        }
        Vector3 direction = (target.transform.position - transform.position).normalized;
        gun.transform.rotation = Quaternion.LookRotation(Vector3.up, direction);
        Debug.DrawRay(gun.transform.position, direction * 10f);
    }

    /// <summary>
    /// Sets chase position to closest available point on the navmesh to the player.
    /// </summary>
    private Vector3 SetChasePosition(Vector3 target)
    {
        NavMeshHit hit;
        Vector3 newTarget;

        if(NavMesh.SamplePosition(target, out hit, 10f, NavMesh.AllAreas))
        {
            newTarget = hit.position;
            return newTarget;
        }
        else
        {
            Debug.Log("INVALID POINT");
            return Vector3.zero;
        }
    }

    /// <summary>
    /// Line of sight coroutine. Constantly draws ray to target on a delay. Changes
    /// state based on current state and if target within line of sight.
    /// </summary>
    private IEnumerator DrawRayToTarget(float timer)
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            RaycastHit hit;

            Vector3 direction = (target.transform.position - transform.position).normalized;

            Debug.DrawRay(transform.position, direction * 100f);
            if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject == target)
                {
                    if (currentState == GPStates.CHASE)
                    {
                        agent.isStopped = true;
                        agent.ResetPath();
                        ChangeState(GPStates.PLANT);
                        interpolator = 0f;
                        Debug.Log("State changed to PLANT");
                    }
                }
                else
                {
                    if (currentState == GPStates.ATTACK)
                    {
                        StopCoroutine(attackCoroutine);
                        attackCoroutineStarted = false;
                        agent.isStopped = false;
                        ChangeState(GPStates.UPROOT);
                        interpolator = 0f;
                        Debug.Log("State changed to UPROOT");
                    }
                }
            }
        }
    }

    /// <summary>
    /// Coroutine to attack target. Creates a new gameObject and passes start and end parameters
    /// </summary>
    private IEnumerator AttackTarget(float timer)
    {
        while(true)
        {
            yield return new WaitForSeconds(timer);
            CreateObject(gun.transform.position, target.transform.position);
        }
    }

    /// <summary>
    /// Handles creation of bullet object. Bullet is given a start and end position, used in
    /// calculating the projectile arc that the bullet will follow.
    /// </summary>
    void CreateObject(Vector3 start, Vector3 end)
    {
        GameObject bullet = objectPool.NewObject(bulletPrefab, gun.transform.position, Quaternion.identity);
        GunPotatoBullet component = bullet.GetComponent<GunPotatoBullet>();
        float height = Mathf.Abs((end - start).magnitude);

        bullet.transform.position = start;
        component.InitializeValues(start, end, height, target);
    }

    public void ChangeState(GPStates newState) //Changes state from current state to newState
    {
        currentState = newState;
    }
}
