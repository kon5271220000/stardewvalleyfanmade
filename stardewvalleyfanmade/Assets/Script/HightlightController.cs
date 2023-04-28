using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HightlightController : MonoBehaviour
{
    [SerializeField] GameObject _highlighter;
    GameObject _currentTarget;
    public void Highlight(GameObject target)
    {
        if(_currentTarget == target)
        {
            return;
        }
        _currentTarget = target;
        Vector3 _pos = target.transform.position;
        Highlight(_pos);
    }

    public void Highlight(Vector3 position)
    {
        _highlighter.SetActive(true);
        _highlighter.transform.position = position + new Vector3(0,2,0);
    }

    public void Hide()
    {
        _currentTarget = null;
        _highlighter.SetActive(false);

    }
}
