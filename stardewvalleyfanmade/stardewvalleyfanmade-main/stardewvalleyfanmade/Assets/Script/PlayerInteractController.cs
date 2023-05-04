using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    PlayerController _player;
    Rigidbody2D _rb;
    [SerializeField] float _offsetDistnce = 1f;
    [SerializeField] float _sizeofInteractableArea = 1.2f;
    [SerializeReference] HightlightController _highlightController;


    private void Awake()
    {
        _player = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Check();
        if (Input.GetMouseButton(1))
        {
            Interact();
        }
    }

    private void Check()
    {
        Vector2 _pos = _rb.position + _player._lastDirection * _offsetDistnce;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_pos, _sizeofInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interacable hit = c.GetComponent<Interacable>();
            if (hit != null)
            {
                _highlightController.Highlight(hit.gameObject);
                return;
            }
        }      
        
            _highlightController.Hide();        
    }
    private void Interact()
    {
        Vector2 _pos = _rb.position + _player._lastDirection * _offsetDistnce;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_pos, _sizeofInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interacable hit = c.GetComponent<Interacable>();
            if (hit != null)
            {
                hit.Interact(_player);
                break;
            }
        }
    }
}


