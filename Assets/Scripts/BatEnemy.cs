using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : Enemy {

    public float m_IdleTime = 1f;
    public float m_StrollTime = 2f;

    protected Vector2 m_Direction;
    protected float m_StateTimer = 0f;
    protected Transform m_Transform;

    protected override void InitializeEnemy()
    {
        m_Transform = GetComponent<Transform>();
        m_Direction = GetRandomVector();
    }

    protected override EnemyState Idle()
    {
        m_StateTimer += Time.deltaTime;
        if (m_StateTimer > m_IdleTime)
        {
            m_StateTimer = 0f;
            m_Direction = GetRandomVector();
            return EnemyState.STROLL;
        }
        else
        {
            return EnemyState.IDLE;
        }
    }

    protected override EnemyState Stroll()
    {
        m_StateTimer += Time.deltaTime;
        if(m_StateTimer > m_StrollTime)
        {
            m_StateTimer = 0f;
            return EnemyState.IDLE;
        }
        else
        {
            MoveInDirection(m_Direction);
            return EnemyState.STROLL;
        }
    }

    protected void MoveInDirection(Vector2 dir)
    {
        m_Transform.Translate(dir * Time.deltaTime);
    }

    protected Vector2 GetRandomVector()
    {
        float randRot = Random.Range(0f, 360f);
        return new Vector2(Mathf.Cos(randRot), Mathf.Sin(randRot));
    }


}
