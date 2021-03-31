using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the gameobject to jump, using rigidbody physics.
/// </summary>
public class JumpController : MonoBehaviour
{
    //Variables used by the cast to check if they are grounded
    public Vector3 m_groundCheckOffset;
    public Vector3 m_groundCheckSize;
    public LayerMask m_groundLayerMask;

    private Rigidbody m_rb;
    private bool m_isJumping = false;
    public float m_jumpHeight;
    public float m_gravity;
    public bool m_canJump;
    
    
    [Header("Debugging")]
    public bool m_debugTools;
    public Color m_debugToolColor, m_cantJumpColor;


    public PlayerVisualEventsBool m_groundedVisualEvent;
    public PlayerVisualEventsBool m_jumpVisualEvent;
    public PlayerVisualEvents m_startJump;


    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }
    private void OnDrawGizmos()
    {
        if (!m_debugTools) return;

        Gizmos.color = (m_canJump) ? m_debugToolColor : m_cantJumpColor;
        Gizmos.DrawWireCube(transform.position + m_groundCheckOffset, m_groundCheckSize);
    }
    private void Update()
    {

        //Check if they are grounded
        Collider[] col = Physics.OverlapBox(transform.position + m_groundCheckOffset, m_groundCheckSize/2, Quaternion.identity, m_groundLayerMask);
        if (col.Length >= 1)
        {
            m_canJump = true;
            m_groundedVisualEvent.Invoke(true);


        }
        else
        {
            m_canJump = false;
        }
    }

    /// <summary>
    /// The jump functionality.
    /// </summary>
    public void Jump()
    {
        if (m_canJump)
        {
            m_jumpVisualEvent.Invoke(true);
            
        }
    }

    public void StartJump()
    {

        m_rb.velocity = new Vector3(m_rb.velocity.x, Mathf.Sqrt(-2.0f * m_gravity * m_jumpHeight), m_rb.velocity.z);
        m_startJump.Invoke();
    }
}
