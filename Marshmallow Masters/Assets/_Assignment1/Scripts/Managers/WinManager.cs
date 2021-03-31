using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WinEvent : UnityEngine.Events.UnityEvent { }

public class WinManager : MonoBehaviour
{
    public int m_killsToWin;
    public int m_currentKillCount;
    public static WinManager Instance;
    public WinEvent m_winEvent;

    public KeyCode m_winKeycode;
    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(m_winKeycode))
        {
            m_winEvent.Invoke();
        }
    }
    public void AddKillCount()
    {
        m_currentKillCount++;
        if (m_currentKillCount >= m_killsToWin)
        {
            m_winEvent.Invoke();
        }
    }
}
