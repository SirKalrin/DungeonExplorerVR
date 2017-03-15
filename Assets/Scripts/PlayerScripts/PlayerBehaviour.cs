using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    private Equipped Equipped;

	// Use this for initialization
	void Start ()
	{
	    Equipped = GetComponentInChildren<Equipped>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Fire1"))
	    {
	        Equipped.Weapon1.Attack();
	    }
	}
}
