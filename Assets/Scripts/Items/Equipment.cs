using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : Item
{

    public Quality Quality;
    public int Durability;

    public List<Attribute> Attributes;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
