using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Backpack _backpack;
    private Walk _movement;
    private float _atkCooldown;
	// Use this for initialization
	void Start ()
	{
	    _atkCooldown = 0;
	    _backpack = transform.FindChild("Main Camera").FindChild("Canvas").GetComponentInChildren<Backpack>();
	    _movement = GetComponent<Walk>();
        _backpack.ToggleBackpack();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.I))
            _backpack.ToggleBackpack();
        else
            _movement.MoveByInput();
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
	}

    private void Attack()
    {
        RangedWeapon weapon = this.gameObject.GetComponentInChildren<RangedWeapon>();
        if (Time.time > _atkCooldown)
        {
            weapon.Attack();
            _atkCooldown = Time.time + weapon.AttackSpeed;
        }
        //RangedWeapon rangedWeapon = _equipped.Mainhand as RangedWeapon;
        //Quiver quiver = _equipped.Offhand as Quiver;
        //if (rangedWeapon != null && quiver != null && quiver.Projectiles > 0)
        //{
        //    quiver.Projectiles--;
        //    Instantiate(projectile, rangedWeapon.transform);
        //    projectile.GetComponent<Rigidbody>().AddForce(transform.forward * rangedWeapon.Range * rangedWeapon.DamageMultiplier);

        //    Debug.Log("Arrow fired! Arrows left... " + quiver.Projectiles);
        //}
    }
}
