using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon<T> : Weapon
{
    public float DamageMultiplier;
    public List<T> Projectiles;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
