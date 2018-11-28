using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour {

    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //ResetAllTriggers();
        if(Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
        {
            animator.SetBool("isMoving", true);
        }else
        {
            animator.SetBool("isMoving", false);
        }

        SetDirection(h, v);
	}

    public void SetDirection(float horizontalDirection, float verticalDirection)
    {
        if(Mathf.Abs(horizontalDirection) > Mathf.Abs(verticalDirection) && horizontalDirection > 0)
        {
            animator.SetTrigger("isRight");
        }
        if (Mathf.Abs(horizontalDirection) > Mathf.Abs(verticalDirection) && horizontalDirection < 0)
        {
            animator.SetTrigger("isLeft");
        }
        if (Mathf.Abs(horizontalDirection) < Mathf.Abs(verticalDirection) && verticalDirection < 0)
        {
            animator.SetTrigger("isDown");
        }
        if (Mathf.Abs(horizontalDirection) < Mathf.Abs(verticalDirection) && verticalDirection > 0)
        {
            animator.SetTrigger("isUp");
        }
    }

    public void ResetAllTriggers()
    {
        animator.ResetTrigger("isRight");
        animator.ResetTrigger("isUp");
        animator.ResetTrigger("isDown");
        animator.ResetTrigger("isLeft");
    }
}
