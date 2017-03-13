using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItemMgr : MonoBehaviour
{
    public Light LightSource;

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
        LightSource.enabled = true;
        transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
    }
    public void PointerExited()
    {
        LightSource.enabled = false;
        transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
    }

}
