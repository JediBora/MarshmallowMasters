using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunEvent : UnityEngine.Events.UnityEvent { }

/// <summary>
/// The script used to fire bullets from the gun. This script goes on the gun.
/// </summary>
public class Gun_Base : MonoBehaviour
{
    public Gun_Properties_Base m_gunProperties;
    public Transform m_fireSpot;
    public float m_timeBetweenBulets;
    public bool m_isAutomatic;
    private Coroutine m_fireRateCoroutine;
    private bool m_bulletShot;
    private ObjectPooler m_pooler;
    private float newGunVelocity = 50001f;

    #region Reload
    [Header("Ammo Stats")]
    public float m_maxAmmo;
    public float m_reloadTime;
    private float m_currentAmmo;
    private bool m_isReloading;
    
    #endregion

    [Header("Raycast Properties")]
    public LayerMask m_hitLayer;

    #region Events
    public GunActivatedEvents m_gunEvents;

    [System.Serializable]
    public struct GunActivatedEvents
    {
        public GunEvent m_bulletFiredEvent;
        public GunEvent m_gunReloadingEvent;
    }
    #endregion


    private void Start()
    {
        InitializeMe();
    }

    public void InitializeMe()
    {
        m_pooler = ObjectPooler.instance;
        m_currentAmmo = m_maxAmmo;
    }
    /// <summary>
    /// Fires a bullet.
    /// </summary>
    public void FireBullet()
    {
        
        if (!m_gunProperties.m_raycastBullet)
        {
            Rigidbody newBullet = m_pooler.NewObject(m_gunProperties.m_bulletPrefab, m_fireSpot.position, m_fireSpot.rotation).GetComponent<Rigidbody>();
            newBullet.velocity = m_fireSpot.forward * m_gunProperties.m_fireSpeed;

        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(m_fireSpot.position, m_fireSpot.forward, out hit, m_gunProperties.m_raycastDistance, m_hitLayer))
            {
                Health hitHealth = hit.transform.GetComponent<Health>();
                if (hitHealth != null)
                {
                    hitHealth.TakeDamage(m_gunProperties.m_raycastBulletDamage);
                    Debug.Log("Hit: " + hit.transform.gameObject.name + " - Take " + m_gunProperties.m_raycastBulletDamage + " damage");
                }
                
                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForceAtPosition((hit.point - m_fireSpot.position).normalized * m_gunProperties.m_raycastBulletForce, hit.point, ForceMode.Impulse);
                }
            }
        }

        m_gunEvents.m_bulletFiredEvent.Invoke();

    }


    /// <summary>
    /// Fires a bullet while using fire rates. Used by the player.
    /// </summary>
    public void FireBulletWithfirerate()
    {

        if (!m_bulletShot && !m_isReloading)
        {
            FireBullet();
            m_fireRateCoroutine = StartCoroutine(BulletShot());
            m_currentAmmo--;
            if (m_currentAmmo == 0)
            {
                StartCoroutine(Reloading());
                m_gunEvents.m_gunReloadingEvent.Invoke();
            }
        }
    }

    private IEnumerator Reloading()
    {
        m_isReloading = true;
        yield return new WaitForSeconds(m_reloadTime);
        m_currentAmmo = m_maxAmmo;
        m_isReloading = false;
    }

    /// <summary>
    /// The coroutine that determines the firerate of the gun.
    /// </summary>
    /// <returns></returns>
    private IEnumerator BulletShot()
    {
        m_bulletShot = true;
        yield return new WaitForSeconds(m_timeBetweenBulets);
        m_bulletShot = false;
    }
}
