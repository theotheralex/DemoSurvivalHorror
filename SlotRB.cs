using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotRB : MonoBehaviour
{
    private Inventory _inventory;
    public int i;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Drop"))
        {
            _inventory._dropEnabled = true;
        }

        if (Input.GetButtonUp("Drop"))
        {
            _inventory._dropEnabled = false;
        }

        if (_inventory._dropEnabled == true && Input.GetButtonDown("RB"))
        {
            DropItem();
        }
        if (_inventory._dropEnabled == false && Input.GetButtonDown("RB"))
        {
            UseAbility();
        }

        if (transform.childCount <= 0)
        {
            _inventory.isFull[i] = false;
        }
    }
    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }

    public void UseAbility()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<AbilityID>().UseAbility();
            GameObject.Destroy(child.gameObject);
        }
    }
}
