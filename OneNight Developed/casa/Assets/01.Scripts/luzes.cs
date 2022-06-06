using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luzes : MonoBehaviour
{
    [SerializeField] GameObject[] luzesGO;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            foreach(GameObject l in luzesGO)
            {
                // l.SetActive(!true);
                if(l.GetComponent<Light>().enabled == true)
                {
                    l.GetComponent<Light>().enabled = !true;
                }
                else
                {
                    l.GetComponent<Light>().enabled = true;
                }
                
            }
        }
    }
}
