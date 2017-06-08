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
            var audioSource = gameObject.GetComponentInParent<AudioSource>();
            if(audioSource && !audioSource.isPlaying)
                audioSource.Play();

            Stats attackerStats = collider.gameObject.GetComponent<Item>().OwnerStats;
            Stats targetStats = gameObject.transform.parent.GetComponentInParent<Stats>();

            if (attackerStats != targetStats)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<CombatManager>()
                    .Hit(attackerStats, targetStats, isHead);
                if (!collider.transform.parent)
                    Destroy(collider.gameObject);
            }
        }
    }
}
