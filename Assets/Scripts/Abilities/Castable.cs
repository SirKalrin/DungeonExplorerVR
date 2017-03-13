using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castable : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _anim;

    public float Cooldown;
    public double EnergyCost;
    public double HealthCost;

    public int LevelRequired;
    public int IntRequired;
    public int StrRequired;
    public int DexRequired;
    public int VitRequired;

    public bool ShieldRequired;
    public WeaponType WeaponRequired;
    public DamageType DamageTypeRequired;
    public ClassType ClassRequired;

    // Use this for initialization
    void Start ()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
