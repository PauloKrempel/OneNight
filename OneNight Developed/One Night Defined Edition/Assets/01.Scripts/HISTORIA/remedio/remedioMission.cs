using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeySystem;
using NarrativeSystem;

public class remedioMission : MonoBehaviour
{
    public KeyInventory _inventory;
    public Narrative _narrative;
    [SerializeField] AudioSource chamado;
    [SerializeField] GameObject textMission;
    public bool completedMission = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_inventory.remediosEntregues && !completedMission)
        {
            _narrative.blockPlayFitaDOIS = false;
            textMission.SetActive(false);
            completedMission = false;
        }
    }
}
