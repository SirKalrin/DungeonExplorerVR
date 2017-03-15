using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AIController : MonoBehaviour
{

    private AIMovements movementController;
    private AIAnimations animationController;
    private Transform target; //the enemy's target

    public float DetectionDistance = 7;
    public float AttackDistance = 2;
    public float AttackRate = 2;

    void Start()
    {
        //target = GameObject.FindWithTag("Player").transform; //target the player
        movementController = transform.GetComponent<AIMovements>();
        animationController = transform.GetComponent<AIAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        // If there is a target in radius
        if (target != null)
        {
            var distance = Vector3.Distance(transform.position, target.transform.position);
            EngageTarget(distance);
        }
    }

    private void EngageTarget(float distance)
    {
        if (distance > AttackDistance)
        {
            movementController.RotateTowardsTarget(distance, target);

            if (distance > AttackDistance)
            {
                movementController.MoveForward();
                animationController.StopAttackAnimation();
                animationController.StartWalkAnimation();
            }
        }
        else
        {
            animationController.DoAttackAnimation();
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            target = col.gameObject.transform;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.transform.Equals(target))
        {
            target = null;
            animationController.StopWalkAnimation();
        }
    }
}
