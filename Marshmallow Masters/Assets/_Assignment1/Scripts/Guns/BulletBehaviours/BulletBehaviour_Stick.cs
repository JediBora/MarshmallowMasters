using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// An additional bullet class that allows the bullets to stick to objects, and explode on enemy proximity, or if the timer runs out. the bullet will move along with the onject it is stuck on.
/// </summary>
public class BulletBehaviour_Stick : MonoBehaviour
{
    private Rigidbody m_rb;
    public float m_maxTimeToExplode;
    private bool m_canExplode, m_sticking;

    public LayerMask m_detectionMask;
    public float m_detectionRadius;
    public BulletEvent m_explodeEvent;
    private Transform m_initialParent, m_newParent;
    private Coroutine m_explodeTimer;
    private SphereCollider m_collide;
    private Vector3 m_hitPosition;
    private Quaternion m_hitRotation;

    [Header("Debugging")]
    public bool m_debugging;
    public Color m_debugColor;


    
    private void Start()
    {
        m_collide = GetComponent<SphereCollider>();
        
        m_initialParent = transform.parent;
        m_rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        m_canExplode = false;
        m_newParent = null;
        m_sticking = false;
        
    }
    private void Update()
    {
        if (m_sticking)
        {
            transform.position = m_newParent.TransformPoint(m_hitPosition);
            transform.rotation = m_newParent.rotation * m_hitRotation;
            Debug.DrawLine(m_newParent.transform.position, m_newParent.InverseTransformPoint(m_hitPosition) + m_newParent.transform.position, Color.magenta);

        }

        if (!m_canExplode) return;
        Collider[] col = Physics.OverlapSphere(transform.position, m_detectionRadius, m_detectionMask);
        if (col.Length > 0)
        {
            if(m_explodeEvent != null)
            {
                StopCoroutine(m_explodeTimer);
                m_explodeTimer = null;
            }
            Explode();
            return;
        }
    }

    /// <summary>
    /// Called to stick the bullet to an object. The parameter is the object this bullet sticks on. 
    /// </summary>
    /// <param name="p_collidedObject"></param>
    public void StickToObject(Transform p_collidedObject)
    {
        m_collide.enabled = false;
        m_rb.isKinematic = true;
        m_explodeTimer = StartCoroutine(ExplodeTime());
        m_canExplode = true;
        m_sticking = true;
        m_newParent = p_collidedObject;
        m_hitPosition = m_newParent.InverseTransformPoint(transform.position);
        transform.position = m_hitPosition;
        m_hitRotation = transform.rotation;
    }

    /// <summary>
    /// The lifespan of this bullet. If this runs out, it will expire.
    /// </summary>
    /// <returns></returns>
    private IEnumerator ExplodeTime()
    {
        yield return new WaitForSeconds(m_maxTimeToExplode);

        if (m_canExplode)
        {
            Explode();
        }
    }

    /// <summary>
    /// Calls the explode event to perform any explosion events as well as despawning.
    /// </summary>
    private void Explode()
    {
        m_canExplode = false;
        m_rb.isKinematic = false;
        m_collide.enabled = true;
        m_explodeEvent.Invoke();
        
    }

    private void OnDrawGizmos()
    {
        if (!m_debugging) return;
        Gizmos.color = m_debugColor;
        Gizmos.DrawWireSphere(transform.position, m_detectionRadius);

    }
}
