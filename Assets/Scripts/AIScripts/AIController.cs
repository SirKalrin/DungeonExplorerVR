﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameObject target; //the enemy's target
    private AIMovements movementController;
    private AIAnimations animationController;
    private AIStats AIStats;
    private GameObject CombatController;

    private Transform myTransform;
    private Vector3 startPosition;

    public float DetectionDistance = 7;
    public float AttackDistance = 2;
    public float AttackRate;

    private float TimeToStrike;

    void Start()
    {
        movementController = transform.GetComponent<AIMovements>();
        animationController = transform.GetComponent<AIAnimations>();
        myTransform = this.transform;
        AIStats = transform.GetComponent<AIStats>();
        CombatController = GameObject.FindGameObjectWithTag("CombatController"); ;

        startPosition = new Vector3(this.transform.position.x, 0.5200002f, transform.position.z);

        AttackRate = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (AIStats.Health <= 0)
        {
            animationController.DoDeathAnimation();
        }
        else
        {
            // If there is a target in radius
            if (target != null)
            {
                var distance = Vector3.Distance(myTransform.position, target.transform.position);
                EngageTarget(distance);
            }
            else if (Vector3.Distance(transform.position, startPosition) > 1)
            {
                AIStats.IsReturningBack = true;
                movementController.MoveForward(startPosition);
                animationController.StopAttackAnimation();
                animationController.StartWalkAnimation();
            }
            else
            {
                animationController.StopWalkAnimation();
            }
        }
    }

    private void EngageTarget(float distance)
    {
        if (distance > AttackDistance)
        {
            movementController.MoveForward(target.transform.position);
            animationController.StopAttackAnimation();
            animationController.StartWalkAnimation();
            TimeToStrike = Time.time + 0.5f;
        }
        else
        {
            movementController.MoveForward(transform.position);
            movementController.RotateTowardsTarget(distance, target.transform);
            animationController.DoAttackAnimation();
            //Attack
            if (Time.time > TimeToStrike)
            {
                CombatController.GetComponent<CombatManager>().AttackTarget(this.gameObject, target);
                TimeToStrike = Time.time + AttackRate;
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (target == null && col.tag == "Player")
        {
            RaycastHit rayHit;
            Physics.Raycast(transform.position, col.transform.position - transform.position, out rayHit, Mathf.Infinity);
            if (rayHit.transform.tag.Equals("Player"))
            {
                target = col.gameObject;
            }
        }

        else if (target == null && col.tag == "EnemyAI")
        {
            var distance = Vector3.Distance(transform.position, col.transform.position);

            if (distance < 5f)
            {
                var enemyTarget = col.gameObject.GetComponent<AIController>().target;

                if (enemyTarget != null)
                {
                    RaycastHit rayHit;
                    Physics.Linecast(transform.position, col.transform.position, out rayHit);
                    if (rayHit.transform.tag.Equals("EnemyAI"))
                    {
                        target = enemyTarget;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.Equals(target))
        {
            target = null;
            animationController.StopWalkAnimation();
            var enemies = GameObject.FindGameObjectsWithTag("EnemyAI");
            foreach (var enemy in enemies)
            {
                enemy.GetComponent<AIController>().target = null;
            }
        }
    }

}
