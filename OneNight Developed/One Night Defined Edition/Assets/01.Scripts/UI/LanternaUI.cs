using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KeySystem;

public class LanternaUI: MonoBehaviour
{
    [Header("Componentes da Lanterna")]
    [Header("Lanterna")]
    [SerializeField] Light lanternaGO;

    [Header("Bateria")]
    public KeyInventory inventario;
    [SerializeField] GameObject Rabiscos;
    [SerializeField] GameObject bateriaGO;
    [SerializeField] GameObject fullEnergy;
    [SerializeField] GameObject mediumEnergy;
    [SerializeField] GameObject lowEnergy;
    public float timeBateria;
    [SerializeField] float timeBateriaAtual;
    [SerializeField] int[,] bateriasCollected;
    [SerializeField] int bateriasAtivas;
    [Header("Interface")]
    [SerializeField] GameObject textBatteryOver;
    [SerializeField] GameObject textNoNeedReload;
    [SerializeField] GameObject textNoPilhas;
    void Start()
    {
        timeBateria = 180f;
        timeBateriaAtual = timeBateria;
        bateriaGO.SetActive(false);
        textBatteryOver.SetActive(false);
        textNoNeedReload.SetActive(false);
        textNoPilhas.SetActive(false);
    }
    void Update()
    {
        if(lanternaGO.enabled == true)
        {
            timeBateria -= Time.deltaTime;
            bateriaGO.SetActive(true);
        }
        else
        {
            bateriaGO.SetActive(false);

        }

        if(Input.GetKeyDown(KeyCode.R) && timeBateria > 0){
            StartCoroutine(showNoNeedReload());
        }
        else if(Input.GetKeyDown(KeyCode.R) && timeBateria <= 0 && inventario.Pilhas > 0){
            timeBateria = 180f;
            inventario.Pilhas--;
            textBatteryOver.SetActive(false);
            lanternaGO.enabled = true;
        }
        else if(Input.GetKeyDown(KeyCode.R) && timeBateria <= 0 && inventario.Pilhas <= 0){
            StartCoroutine(showNoPilhas());
        }
        verifierBateriaTime();
    }
    public IEnumerator showNoNeedReload()
    {
        textNoNeedReload.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        textNoNeedReload.SetActive(false);
        StopCoroutine(showNoNeedReload());
    }
    public IEnumerator showNoPilhas()
    {
        textNoPilhas.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        textNoPilhas.SetActive(false);
        StopCoroutine(showNoPilhas());
    }
    void verifierBateriaTime()
    {
        if(timeBateria >= 120f)
        {
            bateriasAtivas = 3;
            fullEnergy.SetActive(true);
            mediumEnergy.SetActive(true);
            lowEnergy.SetActive(true);
        }
        else if(timeBateria <= 120f && bateriasAtivas == 3)
        {
            fullEnergy.SetActive(false);
            mediumEnergy.SetActive(true);
            lowEnergy.SetActive(true);
            bateriasAtivas = 2;
        }
        else if(timeBateria <= 60f && bateriasAtivas == 2)
        {
            fullEnergy.SetActive(false);
            mediumEnergy.SetActive(false);
            lowEnergy.SetActive(true);
            bateriasAtivas = 1;
        }
        else if(timeBateria <= 0 && bateriasAtivas == 1)
        {
            fullEnergy.SetActive(false);
            mediumEnergy.SetActive(false);
            lowEnergy.SetActive(false);
            bateriasAtivas = 0;
            textBatteryOver.SetActive(true);
            lanternaGO.enabled = false;
        }
    }
}
