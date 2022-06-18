using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeySystem;
using NarrativeSystem;

public class doorQuartoEnemy : MonoBehaviour
{
    public Narrative _narrative;
    public KeyInventory _inventory;
    public Animator animPorta;
    public bool lightOff = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(_narrative.apagarLuzes && !lightOff)
        {
            animPorta.SetTrigger("openDoor");
            lightOff = true;
        }
    }
}
