using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiverCollectable : PointerInteraction
{
    public void QuiverPickup()
    {
        FindObjectOfType<Equipped>().FillQuiver(12);
        Destroy(gameObject);
    }
}
