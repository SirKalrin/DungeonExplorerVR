using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameObject Target; //the enemy's target
    public float DetectionDistance = 7;
    public float AttackDistance = 2;
    public float AttackRate = 3f;

    private float _attackCooldown;
    private AIMovements _movementController;
    private AIAnimations _animationController;
    private Transform _myTransform;
    private Vector3 _startPosition;
    private GameObject _combatCtr;
    private float _timeToStrike;

    void Start()
    {
        _combatCtr = GameObject.FindGameObjectWithTag("CombatController");
        _movementController = transform.GetComponent<AIMovements>();
        _animationController = transform.GetComponent<AIAnimations>();
        _myTransform = this.transform;
        _startPosition = new Vector3(this.transform.position.x, 44.84886f, transform.position.z);
        _timeToStrike = Time.time;
        _attackCooldown = 1.3f/AttackRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (_stats.Health <= 0)
        //{
        //    Die();
        //}
        //else
        //{
            // If there is a target in radius
            if (Target != null)
            {
                var distance = Vector3.Distance(_myTransform.position, Target.transform.position);
                EngageTarget(distance);
            }
            else if (Vector3.Distance(transform.position, _startPosition) > 1)
            {
                //_stats.IsReturningBack = true;
                _movementController.MoveForward(_startPosition);
                _animationController.StopAttackAnimation();
                _animationController.StartWalkAnimation();
            }
            else
            {
                _animationController.StopWalkAnimation();
            }
        //}
    }

    public void Die()
    {
        _animationController.DoDeathAnimation();
        _movementController.MoveForward(transform.position);
    }

    private void EngageTarget(float distance)
    {
        if (distance > AttackDistance)
        {
            _movementController.MoveForward(Target.transform.position);
            _animationController.StopAttackAnimation();
            _animationController.StartWalkAnimation();
            _timeToStrike = Time.time + 0.5f;
        }
        else
        {
            _movementController.MoveForward(transform.position);
            _movementController.RotateTowardsTarget(distance, Target.transform);
            AttackIfPossible();
        }
    }

    private void AttackIfPossible()
    {
        if (Time.time > _timeToStrike + _attackCooldown && _animationController.IsReadyToAttack())
        {
            _animationController.DoAttackAnimation(AttackRate);
            _combatCtr.GetComponent<CombatManager>().AttackTarget(gameObject, Target);
            _timeToStrike = Time.time + AttackRate;
        }
        else
        {
            _animationController.StopAttackAnimation();
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (Target == null && col.tag == "Player")
        {
            RaycastHit rayHit;
            Physics.Raycast(transform.position, col.transform.position - transform.position, out rayHit, Mathf.Infinity);
            if (rayHit.transform.tag.Equals("Player"))
            {
                Target = col.gameObject;
            }
        }

        else if (Target == null && col.tag == "EnemyAI")
        {
            var distance = Vector3.Distance(transform.position, col.transform.position);

            if (distance < 5f)
            {
                var enemyTarget = col.gameObject.GetComponent<AIController>().Target;

                if (enemyTarget != null)
                {
                    RaycastHit rayHit;
                    Physics.Linecast(transform.position, col.transform.position, out rayHit);
                    if (rayHit.transform.tag.Equals("EnemyAI"))
                    {
                        Target = enemyTarget;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.Equals(Target))
        {
            Target = null;
            _animationController.StopWalkAnimation();
            var enemies = GameObject.FindGameObjectsWithTag("EnemyAI");
            foreach(var enemy in enemies)
            {
                enemy.GetComponent<AIController>().Target = null;
            }
        }
    }

}
