using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeySystem;

public class KeysPoraoColleted : MonoBehaviour
{
    public KeyInventory _inventory;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_inventory.KeysPorao >= 4)
        {
            _inventory.hasKeyQE = true;
        }
    }
}
