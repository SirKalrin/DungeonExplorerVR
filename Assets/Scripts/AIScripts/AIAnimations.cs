using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class AIAnimations : MonoBehaviour
{
    private float animationSpeedMultiplier;
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

    public bool IsReadyToAttack()
    {
        return !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
    }
    public void DoAttackAnimation(float animationSpeed)
    {
        
        animator.SetBool("IsAttacking", true);
        animator.SetFloat("Speed", (1.3f/animationSpeed));
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsAttacking", false);
        }
    }

    public void StopAttackAnimation()
    {
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsWalking", false);
    }

    public void DoDeathAnimation()
    {
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsDying", true);
    }
}
