using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon {

    public DamageType PhysicalDamageType;
    public int MinPhysicalDamage;
    public int MaxPhysicalDamage;
    public int MinElementalDamage;
    public int MaxElementalDamage;
   

    // Use this for initialization
    void Start ()
    {
        Animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("Slashing"))
        {
            Animator.SetInteger("Slash", 0);
        }
    }

    public override void Attack(float playerAttackSpeed)
    {
        Animator.speed = playerAttackSpeed;
        Animator.SetInteger("Slash", 1);
    }
}
