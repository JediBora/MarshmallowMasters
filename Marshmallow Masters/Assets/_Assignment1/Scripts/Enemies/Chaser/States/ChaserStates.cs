using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaserStates : MonoBehaviour
{
    #region Variables
    public enum CStates
    {
        UNSET,
        SPAWN,
        CHASE,
        ATTACK,
        BOUNCE
    };

    public CStates currentState;

    private ObjectPooler objectPool;
    private Chaser chaserStateMachine;

    private GameObject target;
    private GameObject attackRadius;

    [SerializeField] private NavMeshAgent agent;

    private Vector3 predictedPos;
    private Vector3 bounceStart;
    private Vector3 bounceEnd;

    public float agentChargeModifier;
    private float bounceTimer;
    private float bounceHeight;
    #endregion

    /// <summary>
    /// Called when object enabled. Ensures variables are set properly before
    /// start is called.
    /// </summary>
    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        chaserStateMachine = GetComponent<Chaser>();
        objectPool = ObjectPooler.instance;
        attackRadius = transform.GetChild(2).gameObject;
        agentChargeModifier = 3f;
        attackRadius.SetActive(false);
    }

    private void Start() //Sets target
    {
        target = chaserStateMachine.target;
    }

    /// <summary>
    /// Spawn state. Enemy rises from the ground
    /// </summary>
    public void Spawn()
    {
        agent.baseOffset += 1 * Time.deltaTime;
        if (agent.baseOffset >= 0.6f)
        {
            ChangeState(CStates.CHASE);
            Debug.Log("State changed to CHASE");
        }
        Debug.DrawLine(transform.position, target.transform.position, Color.red);
    }

    /// <summary>
    /// Called after Spawn behaviour. Simply moves agent to target position,
    /// or closest position on the navmesh
    /// </summary>
    public void Chase()
    {
        float distanceToTarget;

        if (attackRadius.activeSelf)
        {
            attackRadius.SetActive(false);
        }

        agent.speed = 5f;
        agent.SetDestination(SetChasePosition(target.transform.position));

        distanceToTarget = (target.transform.position - transform.position).magnitude;
        if (distanceToTarget <= 10f)
        {
            agent.acceleration *= agentChargeModifier;
            agent.speed *= agentChargeModifier;
            predictedPos = target.transform.position + (target.GetComponent<MovementController>().GetVelocity());
            ChangeState(CStates.ATTACK);
            Debug.Log("State changed to ATTACK");
        }
    }

    /// <summary>
    /// Called when agent is within a certain distance of target. Agent rushes in a straight
    /// line towards target.
    /// </summary>
    public void Attack()
    {
        Vector3 chargeDirection;
        RaycastHit hit;

        if (!attackRadius.activeSelf)
        {
            attackRadius.SetActive(true);
        }

        chargeDirection = transform.forward;

        Debug.DrawRay(transform.position, chargeDirection);
        Debug.DrawLine(transform.position, (transform.position - (transform.forward * 3f)), Color.red);

        agent.SetDestination(SetChasePosition(predictedPos));

        Debug.DrawLine(transform.position, agent.destination);
        if((agent.destination - new Vector3(transform.position.x, transform.position.y - (transform.localScale.y / 2), transform.position.z)).magnitude <= 0.5f)
        {
            agent.speed /= agentChargeModifier;
            agent.acceleration /= agentChargeModifier;
            ChangeState(CStates.CHASE);
        }
    }

    /// <summary>
    /// Bounce state. Called when agent impacts an object. Causes the agent to bounce
    /// backwards off of the object due to it's impact strength
    /// </summary>
    public void Bounce()
    {
        if (attackRadius.activeSelf)
        {
            attackRadius.SetActive(false);
        }

        bounceTimer += Time.deltaTime;
        bounceTimer = bounceTimer % 5f;

        transform.position = MathParabola.Parabola(bounceStart, bounceEnd, bounceHeight, bounceTimer);

        if(bounceTimer >= 1f)
        {
            ChangeState(CStates.CHASE);
        }
    }

    /// <summary>
    /// Helper method to set the chase position
    /// </summary>
    private Vector3 SetChasePosition(Vector3 target)
    {
        NavMeshHit hit;
        Vector3 newTarget;

        if (NavMesh.SamplePosition(target, out hit, 10f, NavMesh.AllAreas))
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

    public void ChangeState(CStates newState) //Changes current state to newState
    {
        currentState = newState;
    }

    /// <summary>
    /// Helper method to calculate the arch in which the agent will bounce
    /// when colliding with an object.
    /// </summary>
    private void CalculateBounceArc()
    {
        NavMeshHit hit;
        bounceStart = transform.position;
        bounceEnd = transform.position - (transform.forward * 3f);

        if(NavMesh.SamplePosition(bounceEnd, out hit, 5f, NavMesh.AllAreas))
        {
            bounceEnd = hit.position;
        }
        bounceHeight = (bounceEnd - bounceStart).magnitude * 0.5f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currentState == CStates.ATTACK)
        {
            ChangeState(CStates.BOUNCE);
            bounceTimer = 0f;
            CalculateBounceArc();
        }
    }
}
