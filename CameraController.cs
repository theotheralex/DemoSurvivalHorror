using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject _followTarget;
    private Vector3 _targetPos;
    public float _moveSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _targetPos = new Vector3(_followTarget.transform.position.x, _followTarget.transform.position.y + 2, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _targetPos, _moveSpeed * Time.deltaTime);
    }
}
