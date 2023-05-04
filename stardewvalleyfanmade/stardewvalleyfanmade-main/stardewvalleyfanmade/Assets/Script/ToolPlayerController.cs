using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPlayerController : MonoBehaviour
{
    private PlayerController _player;
    private Rigidbody2D _rb;
    [SerializeField] float _offsetDistnce = 1f;
    [SerializeField] float _sizeofInteractableArea = 1.2f;

    private void Awake()
    {
        _player = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 _pos = _rb.position + _player._lastDirection * _offsetDistnce;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_pos, _sizeofInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}
