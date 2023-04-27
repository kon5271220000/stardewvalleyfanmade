using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCutAble : ToolHit
{
    [SerializeField] public GameObject _pickUpDrop;
    [SerializeField] int _dropCount = 5;
    [SerializeField] float _spread = 0.7f;
    public override void Hit()
    {
        base.Hit();

        while (_dropCount > 0)
        {
            _dropCount -= 1;

            Vector3 _pos = transform.position;
            _pos.x += _spread * UnityEngine.Random.value - _spread / 2;
            _pos.y += _spread * UnityEngine.Random.value - _spread / 2;
            GameObject _go = Instantiate(_pickUpDrop);
            _go.transform.position = _pos;
        }
        Destroy(gameObject);
    }
}
