using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    // Item Properties
    public string Name;
    public int Quantity;
    private bool _isGlowing;
    public ClassType ClassRequired;
    public List<Attribute> Attributes;
    public Stats OwnerStats;

    //public int LevelRequired;
    //public int IntRequired;
    //public int StrRequired;
    //public int DexRequired;
    //public int VitRequired;

    


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
