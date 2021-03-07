using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilFlask : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask groundLayer;
    public bool onRightWall;
    public bool onLeftWall;
    public bool onTopWall;
    public bool onGround;
    public GameObject _oilPool;
    public GameObject _oilTop;
    public GameObject _oilLeft;
    public GameObject _oilRight;
    public bool _isThrown = true;

    [Header("Collision")]

    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset, rightOffset, leftOffset, topOffset;
    private Color debugCollisionColor = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        onTopWall = Physics2D.OverlapCircle((Vector2)transform.position + topOffset, collisionRadius, groundLayer);
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer);
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);

        

        if(onGround == true)
        {
            Instantiate(_oilPool, transform.position + new Vector3(0, .25f, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (onTopWall == true)
        {
            Instantiate(_oilTop, transform.position + new Vector3(0, -.32f, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (onLeftWall == true)
        {
            Instantiate(_oilLeft, transform.position + new Vector3(-.15f, 0, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (onRightWall == true)
        {
            Instantiate(_oilRight, transform.position + new Vector3(-.33f, 0, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset, topOffset};

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + topOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
    }
}
