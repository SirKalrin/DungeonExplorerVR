using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string Name;

    public int Quantity;
    public int LevelRequired;
    public int IntRequired;
    public int StrRequired;
    public int DexRequired;
    public int VitRequired;

    public ClassType ClassRequired;

    public List<Attribute> Attributes;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
