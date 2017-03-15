using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AIController : MonoBehaviour
{

    private AIMovements movementController;
    private AIAnimations animationController;
    private GameObject target; //the enemy's target
    private Transform myTransform;

    public float DetectionDistance = 7;
    public float AttackDistance = 2;
    public float AttackRate = 2;

    void Start()
    {
        //target = GameObject.FindWithTag("Player").transform; //target the player
        movementController = transform.GetComponent<AIMovements>();
        animationController = transform.GetComponent<AIAnimations>();
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // If there is a target in radius
        if (target != null)
        {
            var distance = Vector3.Distance(myTransform.position, target.transform.position);
            //Debug.Log("Orc position" + myTransform.position);
            //Debug.Log("Our position" + target.transform.position);
            EngageTarget(distance);
        }
    }

    private void EngageTarget(float distance)
    {
        //Debug.Log("Distance: " + distance);
        //Debug.Log("ATKDistance: " + AttackDistance);
        movementController.RotateTowardsTarget(distance, target.transform);

        if (distance > AttackDistance)
        {
                movementController.MoveForward();
                animationController.StopAttackAnimation();
                animationController.StartWalkAnimation();
        }
        else
        {
            animationController.DoAttackAnimation();
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (target == null && col.tag == "Player")
        {
            target = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.Equals(target))
        {
            target = null;
            animationController.StopWalkAnimation();
        }
    }
}
