using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimations : MonoBehaviour
{

    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartWalkAnimation()
    {
        animator.SetBool("IsWalking", true);
    }

    public void StopWalkAnimation()
    {
        animator.SetBool("IsWalking", false);
    }

    public void DoAttackAnimation()
    {
        animator.SetBool("IsAttacking", true);
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsWalking", false);
        }
    }

    public void StopAttackAnimation()
    {
        animator.SetBool("IsAttacking", false);
    }

    public void DoDeathAnimation()
    {
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsDying", true);
    }
}
