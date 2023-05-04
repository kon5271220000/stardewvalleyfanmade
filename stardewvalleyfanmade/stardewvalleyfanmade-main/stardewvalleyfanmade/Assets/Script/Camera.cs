using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform _playerPos;
    private float _speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = new Vector3(_playerPos.position.x, _playerPos.position.y, -10);
        transform.position = Vector3.Slerp(transform.position, newPos, _speed * Time.deltaTime);
    }
}
