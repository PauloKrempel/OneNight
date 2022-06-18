using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NarrativeSystem;

public class luzes : MonoBehaviour
{
    [SerializeField] GameObject[] luzesGO;
    [SerializeField] GameObject chaves;
    [SerializeField] GameObject passos;
    public Narrative _narrative;
    [SerializeField] bool apagou = false;
    void Start()
    {
        chaves.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_narrative.deuPlayNaFitaDOIS && !apagou)
        {
            foreach(GameObject l in luzesGO)
            {
                // l.SetActive(!true);
                if(l.GetComponent<Light>().enabled == true)
                {
                    l.GetComponent<Light>().enabled = !true;
                } 
            }
            
            _narrative.apagarLuzes = true;
            chaves.SetActive(true);
            passos.SetActive(false);
            apagou = true;
        }
    }
}
