using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RangedWeapon : Weapon
{
    public int Projectiles = 10;
    public Transform ProjectileSpawn;
    public GameObject ProjectilePrefab;
    public float DamageMultiplier;

	// Use this for initialization
	void Start ()
	{
        Animator = GetComponent<Animator>();
        Attack1 = GetComponent<AudioSource>();
        ProjectilePrefab.GetComponent<Equipment>().OwnerStats = OwnerStats;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public override void Attack(float playerAttackSpeed)
    {

            if (Projectiles > 0)
            {
                Projectiles--;
                var projectile = Instantiate(ProjectilePrefab, ProjectileSpawn.position,
                    ProjectileSpawn.rotation);
                projectile.transform.forward = Camera.main.transform.forward;
                projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward*Range/10;
                if (!Attack1.isPlaying)
                    Attack1.Play();
                Destroy(projectile, 10f);
            }
    }
}
