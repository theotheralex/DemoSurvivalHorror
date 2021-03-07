using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Animator anim;
    public bool _inRange;
    private Damage _keys;

    // Start is called before the first frame update
    void Start()
    {
        _keys = FindObjectOfType<Damage>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Use") && _inRange == true)
        {
            _keys.AddKey(1);
            anim.SetBool("PickUp", true);
            Destroy(this.gameObject);
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
