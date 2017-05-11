using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Equipment
{
    public WeaponType WeaponType;
    public AudioSource Attack1;
    public AudioSource Hit1;
    public float Range;
    
    public bool IsTwoHanded;
    public Animator Animator;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

    }

    public abstract void Attack(float playerAttackSpeed);
}
