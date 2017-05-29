using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiverCollectable : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            
            Debug.Log(collider.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponentInChildren<RangedWeapon>());
            collider.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponentInChildren<RangedWeapon>().Projectiles +=
                10;           
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;        
            Destroy(gameObject, gameObject.GetComponent<AudioSource>().clip.length);
        }
    }
}
