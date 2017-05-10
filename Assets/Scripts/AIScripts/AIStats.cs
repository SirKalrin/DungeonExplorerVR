using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStats : Stats
{
    [SerializeField]
    private Collider _hitbox;
    private CombatManager _combatMgr;
    public int Damage;
    public bool IsReturningBack;

	// Use this for initialization
	void Start ()
	{
	    Level = 1;

        Health = 100*Level;

	    MaxHealth = 100*Level;

	    Damage = 20*Level;
	}
	
	// Update is called once per frame
	void Update () {
		if(IsReturningBack)
        {
            if(Health < MaxHealth)
            {
                Health++;
            }
            else
            {
                IsReturningBack = false;
            }
        }
	}

}
