using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RangedWeapon : Weapon
{
    private Quiver _quiver;

    public Transform ProjectileSpawn;

    public float DamageMultiplier;

	// Use this for initialization
	void Start ()
	{
	    _quiver = transform.parent.GetComponentInParent<Equipped>().Equipables.FirstOrDefault(x => x.tag == "Offhand").GetComponentInChildren<Quiver>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public override void Attack()
    {
        if (_quiver != null)
        {
            if (_quiver.Projectiles > 0)
            {
                _quiver.Projectiles--;
                var projectile = Instantiate(_quiver.ProjectilePrefab, ProjectileSpawn.position,
                    ProjectileSpawn.rotation);
                projectile.transform.forward = Camera.main.transform.forward;
                projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward*Range/10;
                Debug.Log("Attacked");
                Destroy(projectile, 10f);
            }
        }
    }
}
