using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadContainer : Interacable
{
    [SerializeField] GameObject _closedChest;
    [SerializeField] GameObject _openChest;
    [SerializeField] private bool _opened;
    public override void Interact(PlayerController player)
    {
       
        if(_opened == false)
        {
            _opened = true;
            _closedChest.SetActive(false);
            _openChest.SetActive(true);
        }
    }
}
