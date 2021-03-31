using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerRespawnEvents : UnityEngine.Events.UnityEvent { }
public class PlayerRespawn : MonoBehaviour
{
    public int m_currentLife = 5;

    public PlayerRespawnEvents m_playerOutOfLives;

    public Transform m_respawnPos;
    public PlayerInput m_playerObject;


    public void PlayerDied()
    {
        print("Died");
        m_currentLife -= 1;

        if(m_currentLife == 0)
        {
            m_playerOutOfLives.Invoke();
        }

        m_playerObject.transform.position = m_respawnPos.position;
        m_playerObject.RespawnMe();
    }

    
}
