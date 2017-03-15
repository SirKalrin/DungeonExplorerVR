using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovements : MonoBehaviour
{
    public int MoveSpeed = 3; //move speed
    private Transform myTransform; //current transform data of this enemy

    void Start()
    {
        myTransform = transform; //cache transform data for easy access/preformance
    }

    void FixedUpdate()
    {

    }

    // Rotate towards target Player
    public void RotateTowardsTarget(float distance, Transform enemyTarget)
    {
        var localTarget = transform.InverseTransformPoint(enemyTarget.transform.position);
        var angle = Mathf.Atan2(localTarget.x, localTarget.z)*Mathf.Rad2Deg;
        Vector3 eulerAngleVelocity = new Vector3(0, angle, 0);
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity*Time.deltaTime*10);
        gameObject.GetComponent<Rigidbody>().MoveRotation(gameObject.GetComponent<Rigidbody>().rotation*deltaRotation);
    }

    // Go towards target Player
    public void MoveForward()
    {
        myTransform.position += myTransform.forward * MoveSpeed * Time.deltaTime;
    }

}
