﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int _healthGain;

    //Adds health to the player stepping on the gameobject and plays a sound and destroys the gameobject afterwards. 
    //Needs an audiosource on the gameobject.
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player") 
        {
            collider.GetComponent<Stats>().GainHealth(_healthGain);
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, gameObject.GetComponent<AudioSource>().clip.length);
        }
    }
}
