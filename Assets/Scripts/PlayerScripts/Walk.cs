using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    private CharacterController _charCtrl;
    private Transform _vrHead;


    // Use this for initialization
    void Start()
    {
        _charCtrl = GetComponent<CharacterController>();
        _vrHead = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
            _charCtrl.SimpleMove(_vrHead.TransformDirection(Vector3.forward)*5.0f);
    }

    //Moves the player in the direction of the axis on the controller, relative to where the player is looking. If no axis is active, the player doesnt move.
    public void MoveByInput()
    {
        Vector3 direction = _vrHead.TransformDirection(Vector3.forward);

        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal").Equals(0))
        {
            direction = _vrHead.TransformDirection(Vector3.forward);
            MoveSpeed = 5.0f;
            Debug.Log("Forward");
        }
        else if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal").Equals(0))
        {
            direction = _vrHead.TransformDirection(Vector3.back);
            MoveSpeed = 5.0f;
            Debug.Log("Back");
        }
        else if (Input.GetAxis("Vertical").Equals(0) && Input.GetAxis("Horizontal") > 0)
        {
            direction = _vrHead.TransformDirection(Vector3.right);
            MoveSpeed = 5.0f;
            Debug.Log("Right");
        }
        else if (Input.GetAxis("Vertical").Equals(0) && Input.GetAxis("Horizontal") < 0)
        {
            direction = _vrHead.TransformDirection(Vector3.left);
            MoveSpeed = 5.0f;
            Debug.Log("Left");
        }

        else
        {
            MoveSpeed = 0.0f;
        }

        _charCtrl.SimpleMove(direction*MoveSpeed);
    }
}
