using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletEvent : UnityEngine.Events.UnityEvent { }

[System.Serializable]
public class BulletHitEvent : UnityEngine.Events.UnityEvent <Transform>{ }

/// <summary>
/// The class used by all the bullets. Moves the bullet based on rigid body physics.
/// </summary>
public class BulletBehaviour : MonoBehaviour
{
    public float m_bulletDamage;
    public float m_bulletGravity;
    public BulletEvent m_bulletHitEvent;
    public BulletHitEvent m_bulletHitTransformEvent;

    private Rigidbody m_rb;
    private ObjectPooler m_pooler;

    
    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_pooler = ObjectPooler.instance;
    }

    private void FixedUpdate()
    {
        m_rb.AddForce(Vector3.down * m_bulletGravity, ForceMode.Acceleration);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Health collideHealth = collision.transform.GetComponent<Health>();
        if (collideHealth != null)
        {
            collideHealth.TakeDamage(m_bulletDamage);
        }
        m_bulletHitEvent.Invoke();
        m_bulletHitTransformEvent.Invoke(collision.transform);
    }

    /// <summary>
    /// Used to return the bullet to the object pooler. Should be called through events or script.
    /// </summary>
    public void DespawnBullet()
    {
        m_pooler.ReturnToPool(this.gameObject);
    }

}
