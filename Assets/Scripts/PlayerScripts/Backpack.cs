using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public class Backpack : MonoBehaviour
{

    private SlotToggler _slot1;
    private SlotToggler _slot2;
    private SlotToggler _slot3;
    private SlotToggler _slot4;

    private GameObject _selectedItem;
    private Equipped _equipped;

    

    private bool isOpen;
    // Use this for initialization
    void Start()
    {
        _slot1 = transform.FindChild("Slot1").GetComponent<SlotToggler>();
        _slot2 = transform.FindChild("Slot2").GetComponent<SlotToggler>();
        _slot3 = transform.FindChild("Slot3").GetComponent<SlotToggler>();
        _slot4 = transform.FindChild("Slot4").GetComponent<SlotToggler>();
        _equipped = transform.parent.parent.GetComponentInChildren<Equipped>();
        isOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            DisableSlotLighting();
            _slot4.ActivateSpotlight();
            SetSelectedItem(_slot4);        
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            DisableSlotLighting();
            _slot1.ActivateSpotlight();
            SetSelectedItem(_slot1);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            DisableSlotLighting();
            _slot2.ActivateSpotlight();
            SetSelectedItem(_slot2);

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            DisableSlotLighting();
            _slot3.ActivateSpotlight();
            SetSelectedItem(_slot3);
        }
        else
        {
            DisableSlotLighting();
            _selectedItem = null;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Equip();
        }
    }

    private void SetSelectedItem(SlotToggler slot)
    {
        if (slot.GetComponentInChildren<Item>() == null)
            _selectedItem = null;
        else
        {
            _selectedItem = slot.GetComponentInChildren<Item>().gameObject;
        }
    }

    private void DisableSlotLighting()
    {
        _slot1.DeactivateSpotlight();
        _slot2.DeactivateSpotlight();
        _slot3.DeactivateSpotlight();
        _slot4.DeactivateSpotlight();
    }

    public void ToggleBackpack()
    {
        isOpen = !isOpen;
        gameObject.SetActive(isOpen);
    }

    public void EquipNextItem()
    {
        
    }

    public void Equip()
    {
            GameObject returnedItem = _equipped.Equip(_selectedItem);
            Destroy(_selectedItem);
            if (returnedItem != null)
            Instantiate(returnedItem, _selectedItem.transform.parent);
    }
}
