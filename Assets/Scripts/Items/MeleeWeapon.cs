using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon {

    public DamageType PhysicalDamageType;
    public float MinPhysicalDamage;
    public float MaxPhysicalDamage;
    public float MinElementalDamage;
    public float MaxElementalDamage;
    public Animator anim;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Attack()
    {
        anim.SetInteger("Slash", 1);
    }
}
