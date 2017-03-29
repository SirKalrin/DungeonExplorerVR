using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStats : MonoBehaviour
{
    [SerializeField]
    private Collider _hitbox;
    public int Level = 1;
    public int MaxHealth;
    public int Health;
    private CombatManager _combatMgr;
    public int Damage;
    public bool IsReturningBack;

	// Use this for initialization
	void Start ()
	{
<<<<<<< HEAD
        Health = 100*Level;
=======
	    MaxHealth = 100*Level;
        Health = 30;
>>>>>>> origin/master
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
