using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Equipped : MonoBehaviour
{ 
    public List<GameObject> Equipables;
    private Stats _stats;
    private StatsManager _statsManager;

    void Start()
    {
        _stats = transform.parent.GetComponentInParent<Stats>();
        _statsManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<StatsManager>();
    }

    void Update()
    {
    }

    public GameObject Equip(GameObject prefab)
    {
        GameObject switchedItem = null;
        if (prefab != null)
        {
            var equipSpot = Equipables.FirstOrDefault(x => prefab.tag == x.tag);
            if (equipSpot != null)
            {
                if (equipSpot.GetComponentInChildren<Item>() != null)
                {
                    switchedItem = equipSpot.GetComponentInChildren<Item>().gameObject;
                    _statsManager.RemoveStats(_stats, switchedItem.GetComponent<Equipment>());
                }
                prefab.GetComponent<Item>().OwnerStats = _stats;
                _statsManager.AddStats(_stats, prefab.GetComponent<Equipment>());
                Instantiate(prefab, equipSpot.transform);
            }
        }
        return switchedItem;
    }

    public void FillQuiver(int arrows)
    {
        GetComponentInChildren<Quiver>().Projectiles += arrows;
    }
}
