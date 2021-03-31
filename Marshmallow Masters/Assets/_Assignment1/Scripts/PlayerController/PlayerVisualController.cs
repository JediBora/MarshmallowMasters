using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerVisualEvents: UnityEngine.Events.UnityEvent { }

[System.Serializable]
public class PlayerVisualEventsBool : UnityEngine.Events.UnityEvent<bool> { }

/// <summary>
/// The script used to manage all of the player's animations
/// </summary>
public class PlayerVisualController : MonoBehaviour
{
    public PlayerAnimEvents m_playerEvents;
    private Animator m_animator;
    private bool m_isJumping;
    public float m_jumpTime = 7;
    [System.Serializable]
    public struct PlayerAnimEvents
    {
        public PlayerVisualEvents m_playerJumpEvent;
        public PlayerVisualEvents m_playerDiedEvent;
    }
    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    public void Jump()
    {
        m_playerEvents.m_playerJumpEvent.Invoke();
    }
    public void Died()
    {
        m_playerEvents.m_playerDiedEvent.Invoke();
    }

    public void SetMovmeentBool( bool p_activeState)
    {
        
        m_animator.SetBool("IsWalking", p_activeState);
    }

    public void SetLanded(bool p_activeState)
    {

        if (!m_isJumping)
        {
            m_animator.SetBool("HasLanded", p_activeState);
        }
        else
        {
            m_animator.SetBool("HasLanded", false);
        }
        
    }

    public void SetJumpState(bool p_activeState)
    {
        
        if (p_activeState)
        {
            m_isJumping = true;
            SetLanded(false);
            StartCoroutine(ResetState("IsJumping"));
        }
        m_animator.SetBool("IsJumping", p_activeState);
        
    }

    private IEnumerator ResetState(string p_newState)
    {
        yield return new WaitForSeconds(m_jumpTime);
        if (p_newState == "IsJumping")
        {
            SetJumpState(false);
            m_isJumping = false;
        }
        else if (p_newState == "IsDead")
        {
            SetDeathState(false);
        }
    }

    public void SetDeathState(bool p_activateState)
    {
        SetRespawnState(false);
        m_animator.SetBool("IsDead", p_activateState);
        StartCoroutine(ResetState("IsDead"));

    }

    public void SetRespawnState(bool p_activeState)
    {
        m_animator.SetBool("Respawn", p_activeState);
    }





}
