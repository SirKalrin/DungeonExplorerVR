﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxHit : MonoBehaviour
{
    [SerializeField] private bool isHead;
    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Projectile")
        {
            //GameObject.FindGameObjectWithTag("CombatController").GetComponent<CombatManager>().ProjectileHit(gameObject, collider.gameObject.GetComponent<MeleeWeapon>(), isHead);

            GameObject.FindGameObjectWithTag("CombatController").GetComponent<CombatManager>().MeleeHit(collider.gameObject.GetComponent<Item>().OwnerStats, gameObject.GetComponent<Stats>(), isHead);
        }
    }
}
