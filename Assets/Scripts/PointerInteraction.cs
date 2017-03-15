using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerInteraction : MonoBehaviour {
    [SerializeField]
    private GvrReticlePointer _pointer;
    public void PointerEntered()
    {
        _pointer.GetComponent<MeshRenderer>().enabled = true;
    }
    public void PointerExited()
    {
        _pointer.GetComponent<MeshRenderer>().enabled = false;
    }

    public void Test()
    {
        Debug.Log("Test");
    }

}
