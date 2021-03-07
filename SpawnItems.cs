using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public GameObject[] objects;
    void Start()
    {
            int rand = Random.Range(0, objects.Length);
            Vector3 posToSpawn = new Vector3(0, .3f, 0);
            Instantiate(objects[rand], transform.position + posToSpawn, Quaternion.identity);
            Destroy(this.gameObject);
    }
}

