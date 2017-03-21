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
    private Vector3 startPosition;

    public float DetectionDistance = 7;
    public float AttackDistance = 2;
    public float AttackRate = 2;

    void Start()
    {
        movementController = transform.GetComponent<AIMovements>();
        animationController = transform.GetComponent<AIAnimations>();
        myTransform = this.transform;

        startPosition = new Vector3(this.transform.position.x, 0.5200002f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {


        // If there is a target in radius
        if (target != null)
        {
            var distance = Vector3.Distance(myTransform.position, target.transform.position);
            EngageTarget(distance);
        }
        else if(Vector3.Distance(transform.position, startPosition) > 1)
        {
            movementController.MoveForward(startPosition);
            animationController.StopAttackAnimation();
            animationController.StartWalkAnimation();
        }
        else
        {
            animationController.StopWalkAnimation();
        }
    }

    private void EngageTarget(float distance)
    {
        movementController.RotateTowardsTarget(distance, target.transform);

        if (distance > AttackDistance)
        {
                movementController.MoveForward(target.transform.position);
                animationController.StopAttackAnimation();
                animationController.StartWalkAnimation();
        }
        else
        {
            movementController.MoveForward(transform.position);
            animationController.DoAttackAnimation();
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (target == null && col.tag == "Player")
        {
            RaycastHit rayHit;

            Physics.Linecast(transform.position, col.transform.position, out rayHit);
            Debug.Log("AI position: " + transform.position);
            Debug.Log("Player position: " + col.transform.position);
            Debug.Log("direction: " + (col.transform.position - transform.position));
            if (rayHit.transform.tag.Equals("Player"))
            {
                target = col.gameObject;
            }
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
