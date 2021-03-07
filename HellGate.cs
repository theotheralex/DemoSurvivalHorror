using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellGate : MonoBehaviour
{
    private bool _inRange;
    public bool _shallPass;
    public LevelLoader level;
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        level = FindObjectOfType<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Use") && _inRange == true && _shallPass == false)
        {
            level.LoadLevel(1);
        }
        else if (_inRange == true && _shallPass == true && Input.GetButtonDown("Use"))
        {
            level.LoadLevel(2);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage player = other.transform.GetComponent<Damage>();
        if (other.tag == "Player")
        {
            if (player._currentKey >= 11)
            {
                _shallPass = true;
            }
            CloseDoor();
            PlayerPrefs.SetInt("keys", player._currentKey);
            PlayerPrefs.SetInt("health", player._currenthHealth);
            player._saveHealth = 1;
            PlayerPrefs.SetInt("save", player._saveHealth);
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

    public void CloseDoor()
    {
        anim.SetBool("CloseDoor", false);
    }
}
