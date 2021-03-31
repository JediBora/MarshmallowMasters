using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the player to shoot a gun, if they are holding one.
/// </summary>
public class PlayerGunController : MonoBehaviour
{
    [Tooltip("This is the gun that they are holding. They need to hold a gun in order to be able to activate this function.")]
    public Gun_Base m_currentGun;

    private bool m_firePressed;

    [Header("Aim Assist")]
    public float m_aimAssistSize;
    public LayerMask m_aimAssistMask;
    public float m_minAimDis, m_maxAimDis;
    private Camera m_mainCam;

    private void Start()
    {
        if(m_currentGun == null)
        {
            if (transform.GetChild(0) != null)
            {
                m_currentGun = transform.GetChild(0).GetComponent<Gun_Base>();
            }
            
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        m_mainCam = Camera.main;
    }

    /// <summary>
    /// Calls the fire function on the held gun.
    /// </summary>
    public void FireGun()
    {
        
        if (!m_currentGun.m_isAutomatic && m_firePressed) return;
        PerformAimAssist();
        m_currentGun.FireBulletWithfirerate();
        m_firePressed = true;
    }
    public void FireReleased()
    {
        m_firePressed = false;
    }


    /// <summary>
    /// Rotates the firespot on the current gun to aim properly using the reticle. 
    /// </summary>
    private void PerformAimAssist()
    {
        RaycastHit hit;
        if (Physics.SphereCast(m_mainCam.transform.position, m_aimAssistSize, m_mainCam.transform.forward, out hit, m_maxAimDis, m_aimAssistMask))
        {
            if (Vector3.Distance(m_currentGun.m_fireSpot.position, hit.point) > m_minAimDis)
            {
                m_currentGun.m_fireSpot.LookAt(hit.point);
                return;
            }
        }
        m_currentGun.transform.localRotation = Quaternion.identity;
    }
}
