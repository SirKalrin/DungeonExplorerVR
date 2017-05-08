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

    public GameObject Equip(GameObject prefab)
    {
        var equipSpot = Equipables.FirstOrDefault(x => prefab.tag == x.tag);
        GameObject switchedItem = null;
        if (equipSpot != null)
        {
            if (equipSpot.GetComponentInChildren<Item>() != null)
            {
                switchedItem = equipSpot.GetComponentInChildren<Item>().gameObject;
                GameObject.Destroy(switchedItem);
            }
            Instantiate(prefab, equipSpot.transform);
        }
        return switchedItem;
    }

    public void FillQuiver(int arrows)
    {
        GetComponentInChildren<Quiver>().Projectiles += arrows;
    }
}
