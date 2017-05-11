using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxHit : MonoBehaviour
{
    [SerializeField] private bool isHead;

    //Adds damage to the target via the combatController when a gameobject with tag "projectile" enters the collider. 
    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Projectile")
        {
            //GameObject.FindGameObjectWithTag("CombatController").GetComponent<CombatManager>().ProjectileHit(gameObject, collider.gameObject.GetComponent<MeleeWeapon>(), isHead);

            GameObject.FindGameObjectWithTag("CombatController").GetComponent<CombatManager>().MeleeHit(collider.gameObject.GetComponent<MeleeWeapon>().OwnerStats, gameObject.transform.parent.GetComponentInParent<Stats>(), isHead);
        }
    }
}
