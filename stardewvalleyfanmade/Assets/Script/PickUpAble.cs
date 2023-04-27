using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAble : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _pickupDistance = 1.5f;
    [SerializeField] private float _ttl = 10f;

    private void Awake()
    {
        _player = GameManager._instance._player.transform;
    }

    private void Update()
    {
        _ttl -= Time.deltaTime;
        if (_ttl < 0)
        {
            Destroy(gameObject);
        }
        float _distance = Vector3.Distance(transform.position, _player.position);
        if (_distance > _pickupDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            _player.position,
            _speed * Time.deltaTime);

        if (_distance < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
