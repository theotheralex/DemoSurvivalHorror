using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Space]
    [Header("Positions")]
    public Vector3 pos1;
    public Vector3 pos2;
    [Space]
    [Header("Stats")]
    public float _speed = .5f;
    public bool _static;
    private bool _switch = false;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (_static == false)
        {
            if (_switch == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos2, _speed * Time.deltaTime);
                Debug.Log("this platform is climbing - pos1");
            }
            else if (_switch == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos1, _speed * Time.deltaTime);
                Debug.Log("this platform is climbing - pos2");
            }
        }

        if (transform.position == pos2)
        {
            _switch = true;  
        }
        else if (transform.position == pos1)
        {
            _switch = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _static = false;
            other.transform.parent = this.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
