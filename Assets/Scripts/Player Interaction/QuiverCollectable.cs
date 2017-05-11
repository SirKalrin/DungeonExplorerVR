using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiverCollectable : PointerInteraction
{
    //Adds 12 arrows to the players Quiver. Destroys the gameobject.
    public void QuiverPickup()
    {
        FindObjectOfType<Equipped>().FillQuiver(12);
        Destroy(gameObject);
    }
}
