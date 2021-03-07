using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilPool : MonoBehaviour
{
    public bool _onFire;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Light" && _onFire == false)
        {
            _onFire = true;
            anim.SetBool("onFire", true);
        }

        if (other.tag == "Player" && _onFire == false)
        {
            _onFire = true;
            anim.SetBool("onFire", true);
        }
    }
}
