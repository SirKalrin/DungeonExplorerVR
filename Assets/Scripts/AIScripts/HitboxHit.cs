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
            if(!audioSource.isPlaying)
                audioSource.Play();
            GameObject.FindGameObjectWithTag("GameController").GetComponent<CombatManager>().Hit(collider.gameObject.GetComponent<Item>().OwnerStats, gameObject.transform.parent.GetComponentInParent<Stats>(), isHead);
            Destroy(collider.gameObject);
        }
    }
}
