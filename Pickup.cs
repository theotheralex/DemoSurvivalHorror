using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory _inventory;
    public GameObject _itemButton;
    public bool _inRange;
    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Use") && _inRange == true)
        {
            for (int i = 0; i < _inventory.slots.Length; i++)
            {
                if (_inventory.isFull[i] == false)
                {
                    _inventory.isFull[i] = true;
                    Instantiate(_itemButton, _inventory.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _inRange = false;
        }
    }
}
