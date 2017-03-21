using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovements : MonoBehaviour
{
    public int MoveSpeed = 3; //move speed
    private Transform myTransform; //current transform data of this enemy
    private NavMeshAgent agent;

    void Start()
    {
        myTransform = transform; //cache transform data for easy access/preformance
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); ;
    }

    // Rotate towards target Player
    public void RotateTowardsTarget(float distance, Transform enemyTarget)
    {
        Vector3 direction = (enemyTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * MoveSpeed);
    }

    // Go towards target Player
    public void MoveForward(Vector3 target)
    {
        agent.destination = target;
    }

}
