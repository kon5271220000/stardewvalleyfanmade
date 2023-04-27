using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    private Rigidbody2D _rb;
    private Animator _anim;

    [Header("Movement Variables")]
    private float _speed = 5f;
    private Vector2 _playerPos;
    public Vector2 _lastDirection;
    private float _horizontalDirection;
    private float _verticalDirection;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalDirection = GetInput().x;
        _verticalDirection = GetInput().y;

        //animator
        _anim.SetFloat("vertical", _verticalDirection);
        _anim.SetFloat("horizontal", _horizontalDirection);

        if (_horizontalDirection != 0 || _verticalDirection != 0)
        {
            _lastDirection = new Vector2(_horizontalDirection, _verticalDirection);
            _anim.SetBool("onmove", true);
        }
        else
        {
            _anim.SetBool("onmove", false);
        }


    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void MovePlayer()
    {
        _playerPos = transform.position;
        _playerPos.x = _playerPos.x + _speed * _horizontalDirection * Time.deltaTime;
        _playerPos.y = _playerPos.y + _speed * _verticalDirection * Time.deltaTime;
        transform.position = _playerPos;
    }
}
