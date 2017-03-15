using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Equipment
{
    public WeaponType WeaponType;
    public ElementalType ElementalDamageType;
    public DamageType PhysicalDamageType;

    public float Range;
    public float AttackSpeed;

    public bool IsTwoHanded;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract void Attack();
}
