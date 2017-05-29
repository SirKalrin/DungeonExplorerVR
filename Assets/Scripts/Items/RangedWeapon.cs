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
    private float tmpCooldown;

	// Use this for initialization
	void Start ()
	{
        Animator = GetComponent<Animator>();
        Attack1 = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public override void Attack(float playerAttackSpeed)
    {
            if (Projectiles > 0 && Time.time > tmpCooldown)
            {
                Projectiles--;
                GameObject projectile = Instantiate(ProjectilePrefab, ProjectileSpawn.position,
                    ProjectileSpawn.rotation);
                projectile.GetComponent<Item>().OwnerStats = OwnerStats;
                projectile.transform.forward = Camera.main.transform.forward;
                projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward*Range/10;
                if (!Attack1.isPlaying)
                    Attack1.Play();
                Destroy(projectile, 10f);
            tmpCooldown = Time.time + AttackSpeed;
            }
    }
}
