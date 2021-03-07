using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public EnemyAI ai;
    public bool _run;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Damage player = other.transform.GetComponent<Damage>();
            if (player != null)
            {
                player.TakeDamage(05);
            }
        }

        if (other.tag == "Light")
        {
            _run = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Light")
        {
            _run = false;
        }
    }
}
