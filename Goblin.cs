using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public GameObject button;
    private DialogTrigger _dialogTrigger;
    private DialogManager _dialogManager;
    private Animator anim;
    public bool _inRange;
    private bool _displayedButton;
    private bool _dialogTriggered = false;
    public int animID = 1;
    // Start is called before the first frame update
    void Start()
    {
        _dialogTrigger = GetComponent<DialogTrigger>();
         anim = GetComponent<Animator>();
        _dialogManager = FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Use") && _inRange == true && _dialogTriggered == false)
        {
            _dialogTrigger.TriggerDialog();
            _dialogTriggered = true;
        }

        if (Input.GetButtonDown("Use") && _dialogTriggered == true)
        {
            _dialogManager.DisplayNextSentence();
        }
        switch (animID)
        {
            case 1:
                anim.SetBool("alfred", true);
                break;
            case 2:
                anim.SetBool("eddy", true);
                break;
            case 3:
                anim.SetBool("husky", true);
                break;
            case 4:
                anim.SetBool("Arya", true);
                break;
            case 5:
                anim.SetBool("nacho", true);
                break;
            case 6:
                anim.SetBool("jazzy", true);
                break;
            case 7:
                anim.SetBool("drew", true);
                break;
            case 8:
                anim.SetBool("pat", true);
                break;
            case 9:
                anim.SetBool("boss", true);
                break;
            default:
                Debug.Log ("Invaild animID");
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            if (_displayedButton == false)
            {
                Instantiate(button, transform.position + new Vector3(0.1f, 0.6f, 0), Quaternion.identity);
                _displayedButton = true;
            }
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
