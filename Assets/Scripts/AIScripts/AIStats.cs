using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStats : MonoBehaviour
{

    public int Level = 1;
    public int Health;

    public int Damage;

	// Use this for initialization
	void Start ()
	{
	    Health = 100*Level;
	    Damage = 20*Level;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
