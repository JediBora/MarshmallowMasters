using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager_Agent : MonoBehaviour
{
    public void IWasKilled()
    {
        WinManager.Instance.AddKillCount();
    }
}
