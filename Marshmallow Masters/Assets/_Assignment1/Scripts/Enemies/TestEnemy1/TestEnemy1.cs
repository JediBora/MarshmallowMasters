using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestEnemy1 : Enemy
{
    [field: SerializeField] public override float Health { get; protected set; }

    public enum States
    {
        UNSET,
        IDLE,
        PATROL,
        CHASE,
        ATTACK
    };

    private States currentState;

    [SerializeField] private NavMeshAgent agent;


    private void Start()
    {
        if (currentState == States.UNSET)
        {
            currentState = States.IDLE;
        }
        aiManager = GameObject.Find("AIManager").GetComponent<AIManager>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //ApplyDamage(20f);
        //Kill();
        if(Input.GetKeyUp(KeyCode.A))
        {
            ApplyDamage(20f);
        }
        if(Health <= 0f)
        {
            Kill();
        }
        StateMachine();
    }

    void StateMachine()
    {
        switch (currentState)
        {
            case States.IDLE:
                {
                    break;
                }
            case States.PATROL:
                {
                    break;
                }
            case States.CHASE:
                {
                    break;
                }
            case States.ATTACK:
                {
                    break;
                }
        }
    }

    public void ChangeState(States newState)
    {
        currentState = newState;
    }
}
