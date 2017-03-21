using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{


	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        //RangedWeapon rangedWeapon = _equipped.Mainhand as RangedWeapon;
        //Quiver quiver = _equipped.Offhand as Quiver;
        //if (rangedWeapon != null && quiver != null && quiver.Projectiles > 0)
        //{
        //    quiver.Projectiles--;
        //    Instantiate(projectile, rangedWeapon.transform);
        //    projectile.GetComponent<Rigidbody>().AddForce(transform.forward * rangedWeapon.Range * rangedWeapon.DamageMultiplier);

        //    Debug.Log("Arrow fired! Arrows left... " + quiver.Projectiles);
        //}
        this.gameObject.GetComponentInChildren<RangedWeapon>().Attack();
    }
}
