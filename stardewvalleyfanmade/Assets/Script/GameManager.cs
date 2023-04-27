using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    [SerializeField] public GameObject _player;
    private void Awake()
    {
        _instance = this;
    }

}
