using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual : MonoBehaviour
{
    public float _distance = 3f;
    public EnemyAI ai;
    public Damage dmg;
    RaycastHit2D up;
    RaycastHit2D down;
    RaycastHit2D left;
    RaycastHit2D right;

    void Start()
    {
        ai = GetComponent<EnemyAI>();
       dmg = GameObject.FindGameObjectWithTag("Player").GetComponent<Damage>();
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        up = Physics2D.Raycast(transform.position, transform.up, _distance);
        down = Physics2D.Raycast(transform.position, -transform.up, _distance);
        left = Physics2D.Raycast(transform.position, -transform.right, _distance);
        right = Physics2D.Raycast(transform.position, transform.right, _distance);

        if (up.collider != null)
        {
            Debug.DrawLine(transform.position, up.point, Color.red);

            if (up.collider.CompareTag("Player"))
            {
                Debug.Log("Spotted Player");
                ai.Hunt();
                ai.Speed();
                dmg.AddStress();
            }
            if (up.collider.CompareTag("Light"))
            {
                ai.Flee();
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.up * _distance, Color.green);
        }

        if (down.collider != null)
        {
            Debug.DrawLine(transform.position, down.point, Color.red);

            if (down.collider.CompareTag("Player"))
            {
                ai.Hunt();
                ai.Speed();
                dmg.AddStress();
            }
            if (down.collider.CompareTag("Light"))
            {
                ai.Flee();
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + -transform.up * _distance, Color.green);
        }

        if (left.collider != null)
        {
            Debug.DrawLine(transform.position, left.point, Color.red);

            if (left.collider.CompareTag("Player"))
            {
                ai.Hunt();
                ai.Speed();
                dmg.AddStress();
            }
            if (left.collider.CompareTag("Light"))
            {
                ai.Flee();
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + -transform.right * _distance, Color.green);
        }

        if (right.collider != null)
        {
            Debug.DrawLine(transform.position, right.point, Color.red);

            if (right.collider.CompareTag("Player"))
            {
                ai.Hunt();
                ai.Speed();
                dmg.AddStress();
            }
            if (right.collider.CompareTag("Light"))
            {
                ai.Flee();
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * _distance, Color.green);
        }
    }
}
