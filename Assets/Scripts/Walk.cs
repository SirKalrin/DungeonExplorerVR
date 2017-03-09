using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    private bool _moveForward;
    private CharacterController _charCtrl;
    private GvrViewer _gvrViewer;
    private Transform _vrHead;


    // Use this for initialization
	void Start ()
	{
	    _charCtrl = GetComponent<CharacterController>();
	    _gvrViewer = transform.GetChild(0).GetComponent<GvrViewer>();
	    _vrHead = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetButton("Fire1"))
        //{
        //    _moveForward = !_moveForward;
        //}
        if (Input.GetButton("Fire1"))
        {
            Vector3 forward = _vrHead.TransformDirection(Vector3.forward);
            _charCtrl.SimpleMove(forward*MoveSpeed);
        }
	}
}
