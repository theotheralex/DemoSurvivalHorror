using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    private Movement move;
    public GameObject[] ability;
    private float _launchforce = 15;
    private float _speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponentInParent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Throw()
    {
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(xRaw, yRaw);
        GameObject newAbility = Instantiate(ability[0], transform.position + Vector3.forward, Quaternion.identity);
        newAbility.GetComponent<Rigidbody2D>().velocity = dir * _launchforce;
    }

    public void Fireball()
    {
        if (move.side == -1)
        {
            GameObject newFireball = Instantiate(ability[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            newFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-_speed, 0);
        }
       else
        {
            GameObject newFireball = Instantiate(ability[1], transform.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            newFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(_speed, 0);
        }
    }

    public void Flame()
    {
        Instantiate(ability[2], transform.position, Quaternion.identity);
    }

    public void Fireblast()
    {
        Instantiate(ability[3], transform.position + new Vector3(0, -.2f, 0), Quaternion.identity);
    }

}
