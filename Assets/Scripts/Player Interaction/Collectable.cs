using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("IMMAGONNABEEATEN!");
        if (collider.gameObject.tag == "Player")
        {
            collider.GetComponent<Stats>().Health += 20;
            Destroy(gameObject);
        }
    }
}
