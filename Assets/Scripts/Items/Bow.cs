using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : RangedWeapon<Arrow>
{

	// Use this for initialization
	void Start ()
	{
	    for (int i = 0; i < 10; i++)
	    {
            Projectiles.Push(new Arrow());
        }
	    Debug.Log(Projectiles.Count);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Attack()
    {
        Projectiles.Pop();
        Debug.Log("Arrow shot!! Arrows left: " + Projectiles.Count);
    }
}
