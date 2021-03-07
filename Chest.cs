using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] items;
    public GameObject button;
    private bool _inRange;
    private bool _displayedButton;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Use") && _inRange == true)
        {
            Vector3 posToSpawn = new Vector3(0, -0.2f, 0);
            Vector3 posLeft = new Vector3(-1f, -0.2f, 0);
            Vector3 posRight = new Vector3(1f, -0.2f, 0);
            int randomItem1 = Random.Range(0, items.Length);
            int randomItem2 = Random.Range(0, items.Length);
            int randomItem3 = Random.Range(0, items.Length);
            Instantiate(items[randomItem1], transform.position + posRight, Quaternion.identity);
            Instantiate(items[randomItem2], transform.position + posToSpawn, Quaternion.identity);
            Instantiate(items[randomItem3], transform.position + posLeft, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if (_displayedButton == false)
            {
                Instantiate(button, transform.position + new Vector3(-0.1f, 0.3f, 0), Quaternion.identity);
                _displayedButton = true;
            }
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
