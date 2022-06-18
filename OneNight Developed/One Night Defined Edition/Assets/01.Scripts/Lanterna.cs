using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeySystem;

public class Lanterna : MonoBehaviour
{
    [SerializeField] GameObject lanternaGO;
    public LanternaUI lanternaController;
    public KeyInventory _inventory;
    [SerializeField] GameObject textNeedLanterna;
    void Start()
    {
        lanternaGO.GetComponent<Light>().enabled = false;
        textNeedLanterna.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        controlLanter();
    }
    void controlLanter()
    {
        if(Input.GetKeyDown(KeyCode.F) && lanternaController.timeBateria > 0 && _inventory.lanterna)
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
        else
        {
            //StartCoroutine(avisoLanterna());
        }
    }
    IEnumerator avisoLanterna()
    {
        textNeedLanterna.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        textNeedLanterna.SetActive(false);
        StopCoroutine(avisoLanterna());
    }
}
