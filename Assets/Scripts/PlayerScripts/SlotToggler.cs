using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotToggler : MonoBehaviour
{
    private GameObject _spotLight;
	// Use this for initialization
	void Start ()
	{
	    _spotLight = transform.FindChild("Spotlight").gameObject;
        _spotLight.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DeactivateSpotlight()
    {
        _spotLight.SetActive(false);
    }
    public void ActivateSpotlight()
    {
        _spotLight.SetActive(true);
    }
}
