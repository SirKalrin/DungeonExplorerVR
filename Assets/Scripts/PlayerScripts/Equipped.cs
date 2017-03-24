using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Equipped : MonoBehaviour
{ 
    public List<GameObject> Equipables;
    public GameObject ToBeEquipeed;
    public GameObject ToBeEquipeed2;

    void Start()
    {
        Equip(ToBeEquipeed);
        Equip(ToBeEquipeed2);
    }

    void Update()
    {
    }

    void Equip(GameObject prefab)
    {
        var equipSpot = Equipables.FirstOrDefault(x => prefab.tag == x.tag);
        if (equipSpot != null)
            Instantiate(prefab, equipSpot.transform);
    }
}
