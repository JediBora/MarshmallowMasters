using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the gameobject to move on the X and Y axis. Uses Rigid body physics.
/// </summary>
public class MovementController : MonoBehaviour
{
    public float m_maxSpeed;
    public float m_acceleration;
    public float m_deceleration;


    private float m_currentSpeed;
    private Rigidbody m_rb;

    public Transform m_rootTransform;

    public PlayerVisualEventsBool m_movmementVisualEvent;
    private bool m_canMove = true;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// The function that moves the gameobject, using the inputed paramerter as its direction.
    /// </summary>
    /// <param name="p_dir"></param>
    public void MoveController(Vector3 p_dir)
    {
        if (p_dir.magnitude > 0 && m_canMove)
        {
            m_movmementVisualEvent.Invoke(true);

            m_currentSpeed += m_acceleration / 60;
            if (m_currentSpeed > m_maxSpeed)
            {
                m_currentSpeed = m_maxSpeed;
            }
        }
        else
        {
            m_movmementVisualEvent.Invoke(false);
            if (m_currentSpeed > 0)
            {
                m_currentSpeed -= m_deceleration;
            }
            else
            {
                m_currentSpeed = 0;
            }
        }
        m_rb.velocity = m_rootTransform.localRotation *  new Vector3((p_dir * m_currentSpeed).x, m_rb.velocity.y, (p_dir * m_currentSpeed).z);
    }


    public void SetMovementState(bool p_activeState)
    {
        m_canMove = p_activeState;

    }

    public Vector3 GetVelocity()
    {
        return m_rb.velocity;
    }
}
