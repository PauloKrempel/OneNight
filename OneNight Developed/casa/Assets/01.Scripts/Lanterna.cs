using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanterna : MonoBehaviour
{
    [SerializeField] GameObject lanternaGO;
    void Start()
    {
        lanternaGO.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        controlLanter();
    }
    void controlLanter()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(lanternaGO.GetComponent<Light>().enabled == false)
            {
                lanternaGO.GetComponent<Light>().enabled = true;
            }
            else
            {
                lanternaGO.GetComponent<Light>().enabled = false;
            }
        }
    }
}
