using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Damage player = other.transform.GetComponent<Damage>();
            if (player != null)
            {
                player.TakeDamage(10);
            }
        }
    }
}
