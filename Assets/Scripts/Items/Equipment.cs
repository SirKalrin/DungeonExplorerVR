using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : Item
{

    public Quality Quality;
    public int MaxDurability;
    public int Durability;

    // Weapon properties
    public float AttackSpeed;

    // Melee properties
    public DamageType PhysicalDamageType;
    public int MinPhysicalDamage;
    public int MaxPhysicalDamage;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

    }
}
