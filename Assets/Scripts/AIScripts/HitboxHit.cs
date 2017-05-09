using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxHit : MonoBehaviour
{
    [SerializeField] private bool isHead;
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("HIT!");
            if (collider.gameObject.tag == "Projectile")
                GameObject.FindGameObjectWithTag("CombatController").GetComponent<CombatManager>().ProjectileHit(gameObject, collider.gameObject.GetComponent<Arrow>(), isHead);
    }
}
