using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    private Movement _player;

    void Start()
    {
        _player = FindObjectOfType<Movement>();
    }
    void Update()
    {
        if (_player.side == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            transform.position = _player.transform.position + new Vector3(1.3f, -0.2f, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = _player.transform.position + new Vector3(-1.3f, -0.15f, 0);
        }

        StartCoroutine(Destroy());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Player"))
        {
           
            this.transform.parent = other.transform;
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
