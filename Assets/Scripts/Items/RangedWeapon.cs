using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon<T> : Weapon
{
    public float DamageMultiplier;
    public Stack<T> Projectiles;

	// Use this for initialization
	void Start () {
        Projectiles = new Stack<T>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
