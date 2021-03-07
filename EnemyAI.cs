using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform[] target;
    public float speed = 300f;
    public float nextWaypointDistance = 3f;
    public int targetID;
    public bool ambushPos;
    public bool huntPos;
    public bool searchPos = true;
    int currentWaypoint = 0;
    bool reachedEndOfPath;
    Path path;
    private EnemyDamage _enemyDmg;
    private Seeker seeker;
    private Rigidbody2D rb;
    private Animator anim;
    private Damage dmg;
    private Transform player;
    void Start()
    {
        _enemyDmg = GetComponent<EnemyDamage>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dmg = FindObjectOfType<Damage>();
        player = GameObject.FindWithTag("Player").transform;
        Scan();


        InvokeRepeating("UpdatePath", 0f, .5f);
    }
    void UpdatePath()
    {
        if (seeker.IsDone() && huntPos == true)
        {
            seeker.StartPath(rb.position, player.position, OnPathComplete);
        }
            
        else
        {
          seeker.StartPath(rb.position, target[targetID].position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Update()
    {
        if (dmg._currentStress >= 120)
        {
            huntPos = false;
            Search();
        }

        if (searchPos == true)
        {
            huntPos = false;
            Search();
        }

        if (_enemyDmg._run == true)
        {
            Flee();
        }
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    
    public void Speed()
    {
        speed ++;
    }
    public void Flee()
    {
        huntPos = false;
        anim.SetBool("Stealth", true);
        int randomPos = Random.Range(1, 16);
        targetID = randomPos;
        searchPos = false;
    }
    public void Hunt()
    {
        anim.SetBool("Stealth", false);
        huntPos = true;
        searchPos = false;
    }

    public void Search()
    {
        anim.SetBool("Stealth", false);
        huntPos = false;
        int randomPos = Random.Range(1, 16);
        targetID = randomPos;
        searchPos = false;
    }
    private void Scan()
    {
        var graphToScan = AstarPath.active.data.gridGraph;
        AstarPath.active.Scan(graphToScan);
    }
}
