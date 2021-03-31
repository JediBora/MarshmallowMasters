using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Swaps the gun on the player
/// </summary>
public class Gun_Swapping : MonoBehaviour
{

    private PlayerGunController m_playerGunController;
    public KeyCode m_swapKeycode;


    public Gun_Base m_heldGun;
    public Transform m_heldGunPlacement;
    void Start()
    {
        m_playerGunController = GetComponent<PlayerGunController>();
        m_heldGun.InitializeMe();
        m_heldGun.enabled = false;
        m_heldGun.transform.parent = m_heldGunPlacement;
        m_heldGun.transform.position = m_heldGunPlacement.position;
        m_heldGun.transform.rotation = m_heldGunPlacement.rotation;
    }


    void Update()
    {
        if (Input.GetKeyDown(m_swapKeycode))
        {
            SwapGun();
        }
    }

    private void SwapGun()
    {
        Gun_Base swappingTemp = m_playerGunController.m_currentGun;
        m_playerGunController.m_currentGun = m_heldGun;
        m_heldGun.transform.position = transform.position;
        m_heldGun.transform.parent = this.transform;
        m_heldGun.transform.rotation = transform.rotation;
        m_heldGun = swappingTemp;
        m_heldGun.transform.parent = m_heldGunPlacement;
        m_heldGun.transform.position = m_heldGunPlacement.position;
        m_heldGun.transform.rotation = m_heldGunPlacement.rotation;
    }
}
