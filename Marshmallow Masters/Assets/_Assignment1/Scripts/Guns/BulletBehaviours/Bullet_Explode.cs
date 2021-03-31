using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the bullets to explode. Does not spawn explosion particles. Must be called through either events, or script in order to function.
/// </summary>
public class Bullet_Explode : MonoBehaviour
{
    public float m_explosionRadius;
    public float m_explosionDamage;
    public float m_maxExplosionForce;
    public float m_explosionUpForce;
    public LayerMask m_explodeMask;


    [Header("DEbugging")]
    public bool m_debug;
    public Color m_gizmosColor;

    /// <summary>
    /// Creates an explosion around the gameobject's position. Adds damage, as well as explosion force, to any hit objects in its detection layers.
    /// </summary>
    public void Explode()
    {
        print("Explode!");
        Collider[] cols = Physics.OverlapSphere(transform.position, m_explosionRadius, m_explodeMask);
        foreach (Collider col in cols)
        {
            Health currentHealth = col.GetComponent<Health>();
            if (currentHealth != null)
            {
                currentHealth.TakeDamage(m_explosionDamage);
            }

            Rigidbody rb = col.transform.GetComponent<Rigidbody>();
            if (rb!=null)
            {
                rb.AddExplosionForce(m_maxExplosionForce, transform.position, m_explosionRadius, m_explosionUpForce, ForceMode.Impulse);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (m_debug)
        {
            Gizmos.color = m_gizmosColor;
            Gizmos.DrawWireSphere(transform.position, m_explosionRadius);
        }
    }
}
