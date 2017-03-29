using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStats : MonoBehaviour
{

    public int Level = 1;
    public int MaxHealth;
    public int Health;

    public int Damage;
    public bool IsReturningBack;

	// Use this for initialization
	void Start ()
	{
	    MaxHealth = 100*Level;
        Health = 30;
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
