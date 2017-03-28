﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    private bool _moveForward;
    private CharacterController _charCtrl;
    private GvrViewer _gvrViewer;
    private Transform _vrHead;
    private Rigidbody _rb;


    // Use this for initialization
	void Start ()
	{
        Debug.Log("walk");
	    _charCtrl = GetComponent<CharacterController>();
	    _rb = GetComponent<Rigidbody>();

	    //_gvrViewer = transform.GetChild(0).GetComponent<GvrViewer>();
	    _vrHead = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
        Vector3 forward = _vrHead.TransformDirection(Vector3.forward);
        
        if (Input.GetButton("Fire1"))
        {
            MoveSpeed = 5.0f;
            transform.rotation = new Quaternion(transform.rotation.x, forward.y, transform.rotation.z, transform.rotation.w);
        }
        else
        {
            MoveSpeed = 0.0f;
        }
        _charCtrl.SimpleMove(forward * MoveSpeed);
        
	}
}
