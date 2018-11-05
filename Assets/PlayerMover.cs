using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

    public float m_MaxSpeed;
    public float m_SpeedUpTime;
    public float m_DashSpeed;
    public float m_DashTime;
    public float m_DashRecharge;

    private float m_TimeRunning;
    private float m_TimeSinceDash;
    private float m_TimeDashing;
    private bool m_Dashing;
    

    private Rigidbody2D m_RB;
    
	// Use this for initialization
	void Start ()
    {
        m_TimeRunning = 0;
        m_RB = this.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleDashControl();       
        Vector2 inputVector = GetInputVector();
        HandleMovement(inputVector);

        
    }

    //Here we handle the manipulation of the velocity of the player
    private void HandleMovement(Vector2 inputVector)
    {
        if (inputVector.SqrMagnitude() > 0.01f)
        {
            m_TimeRunning += Time.deltaTime;
        }
        else
        {
            m_TimeRunning = 0;
        }
        if (!m_Dashing)
        {
            m_RB.velocity = inputVector * Mathf.Lerp(0.0f, m_MaxSpeed, m_TimeRunning / m_SpeedUpTime);
        }
        else
        {
            if (inputVector.SqrMagnitude() > 0)
            {
                m_RB.velocity = inputVector.normalized * m_DashSpeed;
            }
            else
            {
                m_RB.velocity = Vector2.zero;
            }
        }
    }

    //Here we handle whether or not the player is dashing and whether or not they can
    private void HandleDashControl()
    {
        if (Input.GetAxis("Dash") > .01f && m_TimeSinceDash > m_DashRecharge)
        {
            m_Dashing = true;
        }
        if (!m_Dashing)
        {
            m_TimeDashing = 0f;
            m_TimeSinceDash += Time.deltaTime;
        }
        else
        {
            m_TimeSinceDash = 0f;
            m_TimeDashing += Time.deltaTime;
            if (m_TimeDashing > m_DashTime)
            {
                m_Dashing = false;
            }
        }
    }

    //Determine the 2d vector that represents the direction the player is inputting for movement
    private Vector2 GetInputVector()
    {
        Vector2 inputVector = new Vector2();
        inputVector.y = Input.GetAxis("Vertical");
        inputVector.x = Input.GetAxis("Horizontal");
        Vector2.ClampMagnitude(inputVector, 1);
        return inputVector;
    }


}
