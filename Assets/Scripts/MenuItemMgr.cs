using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItemMgr : MonoBehaviour
{
    public Light LightSource;
    [SerializeField]
    private GvrReticlePointer _pointer;

    public void BClicked()
    {
        SceneManager.LoadScene("BilleTestScene");
    }
    public void MClicked()
    {
        SceneManager.LoadScene("MortensTestScene");
    }
    public void NClicked()
    {
        SceneManager.LoadScene("NicolaiTestScene");
    }

    public void PointerEntered()
    {
        _pointer.GetComponent<MeshRenderer>().enabled = true;
        LightSource.enabled = true;
        transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
    }
    public void PointerExited()
    {
        _pointer.GetComponent<MeshRenderer>().enabled = false;
        LightSource.enabled = false;
        transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
    }

}
