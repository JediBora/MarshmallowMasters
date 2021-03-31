using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A scriptable object script that is used by the gun base script to create a variety of guns.
/// </summary>
[CreateAssetMenu(fileName = "GunType Base", menuName = "ScriptableObjects/Guns/GunBase", order = 0)]
public class Gun_Properties_Base : ScriptableObject
{
    public GameObject m_bulletPrefab;
    public float m_fireSpeed;
    [Header("Raycast Bullets")]
    public bool m_raycastBullet;
    public float m_raycastDistance;
    public float m_raycastBulletForce;
    public float m_raycastBulletDamage;
}
