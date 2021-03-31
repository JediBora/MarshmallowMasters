using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GunPotato : Enemy
{
    #region Variables
    [field: SerializeField] public override float Health { get; protected set; }

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GunPotatoStates states;
    #endregion

    /// <summary>
    /// Called on object enable. Resets all variables to their default values 
    /// to ensure AI runs properly
    /// </summary>
    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        states = GetComponent<GunPotatoStates>();
        Health = 100f;
        states.currentState = GunPotatoStates.GPStates.SPAWN;
        target = GameObject.Find("PFB_Player");
        agent.baseOffset = -0.6f;
        aiManager.AddToList(this.gameObject);
        healthScript.Respawn();
    }

    private void Start()
    {
        if(states.currentState == GunPotatoStates.GPStates.UNSET)
        {
            states.currentState = GunPotatoStates.GPStates.SPAWN;
        }
        
    }

    private void Update()
    {
        if (Health <= 0f)
        {
            Kill();
        }
        StateMachine();
    }

    /// <summary>
    /// Agent state machine. Handles state changing and state execution
    /// </summary>
    void StateMachine()
    {
        switch (states.currentState)
        {
            case GunPotatoStates.GPStates.SPAWN:
                {
                    states.Spawn();
                    break;
                }
            case GunPotatoStates.GPStates.CHASE:
                {
                    states.Chase(target);
                    break;
                }
            case GunPotatoStates.GPStates.PLANT:
                {
                    states.Plant();
                    break;
                }
            case GunPotatoStates.GPStates.UPROOT:
                {
                    states.Uproot();
                    break;
                }
            case GunPotatoStates.GPStates.ATTACK:
                {
                    states.Attack();
                    break;
                }
        }
    }
}
