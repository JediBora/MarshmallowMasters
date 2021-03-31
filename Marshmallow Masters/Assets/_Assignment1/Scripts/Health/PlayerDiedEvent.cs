using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerDiedEvent : MonoBehaviour
{

    public string m_eventName;
    private int m_amountOfPlayerDeaths;


    public void PlayerDied()
    {
        m_amountOfPlayerDeaths++;
    }


    private void OnDestroy()
    {
        TrackPlayerDeaths();
    }
    public void TrackPlayerDeaths()
    {
        Analytics.CustomEvent(m_eventName, new Dictionary<string, object>
        {
            {m_eventName, m_amountOfPlayerDeaths }
        });
    }
}
