﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuItem : PointerInteraction
{
    public Light LightSource;
    private AudioSource _audio;
    [SerializeField]
    private AudioClip _enterSound;
    [SerializeField]
    private AudioClip _exitSound;

    void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();        
    }
    public void BClicked()
    {
        SceneManager.LoadScene("ArenaGamemode");
    }
    public void MClicked()
    {
        SceneManager.LoadScene("MortensTestScene");
    }
    public void NClicked()
    {
        SceneManager.LoadScene("NicolaiTestScene");
    }

    public new void PointerEntered()
    {     
        base.PointerEntered();
        _audio.PlayOneShot(_enterSound);
        LightSource.enabled = true;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.2f);
    }
    public new void PointerExited()
    {
        base.PointerExited();
        _audio.PlayOneShot(_exitSound);
        LightSource.enabled = false;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f);
    }

}
