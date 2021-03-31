using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chaser : Enemy
{
    #region Variables
    [field: SerializeField] public override float Health { get; protected set; }

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private ChaserStates states;
    #endregion

    /// <summary>
    /// Called when object enabled. Resets all variables to ensure AI
    /// works properly.
    /// </summary>
    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        states = GetComponent<ChaserStates>();
        Health = 100f;
        states.currentState = ChaserStates.CStates.SPAWN;
        target = GameObject.Find("PFB_Player");
        agent.baseOffset = -0.6f;
        aiManager.AddToList(this.gameObject);
        healthScript.Respawn();
    }

    private void Start()
    {
        if (states.currentState == ChaserStates.CStates.UNSET)
        {
            states.currentState = ChaserStates.CStates.SPAWN;
        }
    }

    private void Update()
    {
        StateMachine();
    }

    /// <summary>
    /// The state machine for the Chaser AI. Calls the corresponding state
    /// on ChaserStates.cs
    /// </summary>
    void StateMachine()
    {
        switch (states.currentState)
        {
            case ChaserStates.CStates.SPAWN:
                {
                    states.Spawn();
                    break;
                }
            case ChaserStates.CStates.CHASE:
                {
                    states.Chase();
                    break;
                }
            case ChaserStates.CStates.ATTACK:
                {
                    states.Attack();
                    break;
                }
            case ChaserStates.CStates.BOUNCE:
                {
                    states.Bounce();
                    break;
                }
        }
    }
}
