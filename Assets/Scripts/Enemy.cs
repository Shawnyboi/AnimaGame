using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    public enum EnemyState { IDLE, ATTACK, STROLL };

    protected StateMachine<EnemyState> m_StateMachine;

    protected abstract void InitializeEnemy();

    protected virtual void Start()
    {
        InitializeEnemy();
    }

    public Enemy()
    {
        m_StateMachine = new StateMachine<EnemyState>();
        m_StateMachine[EnemyState.IDLE] = Idle;
        m_StateMachine[EnemyState.ATTACK] = Attack;
        m_StateMachine[EnemyState.STROLL] = Stroll;
    }

    virtual protected EnemyState Idle()
    {
        Debug.Log("Idling");
        return EnemyState.IDLE;
    }
    
    virtual protected EnemyState Attack()
    {
        Debug.Log("Attacking");
        return EnemyState.ATTACK;
    }

    virtual protected EnemyState Stroll()
    {
        Debug.Log("Strolling");
        return EnemyState.STROLL;
    }

    virtual protected void Update()
    {
        m_StateMachine.Update();
    }


}
