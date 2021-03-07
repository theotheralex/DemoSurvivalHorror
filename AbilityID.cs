using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityID : MonoBehaviour
{
    private Abilities _ability;
    void Start()
    {
        _ability = GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>();
        
    }
    void Update()
    {

    }
    public void UseAbility()
    {
        if (gameObject.tag == ("OilFlask"))
        {
            _ability.Throw();
        }

        if (gameObject.tag == ("Fireball"))
        {
            _ability.Fireball();
        }

        if (gameObject.tag == ("Flame"))
        {
            _ability.Flame();
        }
        if (gameObject.tag == ("Fireblast"))
        {
            _ability.Fireblast();
        }
    }
}
