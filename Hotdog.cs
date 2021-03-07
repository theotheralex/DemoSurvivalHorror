using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotdog : MonoBehaviour
{
    private Animator anim;
    public bool _inRange;
    private Damage _health;

    // Start is called before the first frame update
    void Start()
    {
        _health = GameObject.FindGameObjectWithTag("Player").GetComponent<Damage>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Use") && _inRange == true)
        {
            if (_health._currenthHealth < 110)
            {
                _health.AddHealth(10);
                anim.SetBool("PickUp", true);
                Destroy(this.gameObject);
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
