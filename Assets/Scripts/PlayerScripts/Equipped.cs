using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipped : MonoBehaviour
{

    public Armor Headgear;
    public Armor Torso;
    public Armor Legs;
    public Armor Gloves;
    public Armor Boots;
    public Armor Cape;
    
    public Equipment LeftRing;
    public Equipment RightRing;
    public Equipment Neckless;
    public Equipment LeftEar;
    public Equipment RightEar;

    public Weapon Mainhand;
    public Item Offhand;

    void Start()
    {
       
    }

    void Update()
    {
        transform.forward = Camera.main.transform.TransformDirection(Vector3.forward);
    }
}
