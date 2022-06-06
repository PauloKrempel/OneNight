using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanternaUI: MonoBehaviour
{
    [Header("Componentes da Lanterna")]
    [Header("Lanterna")]
    [SerializeField] Light lanternaGO;

    [Header("Bateria")]
    [SerializeField] GameObject Rabiscos;
    [SerializeField] GameObject bateriaGO;
    [SerializeField] GameObject fullEnergy;
    [SerializeField] GameObject mediumEnergy;
    [SerializeField] GameObject lowEnergy;
    [SerializeField] float timeBateria;
    [SerializeField] float timeBateriaAtual;
    [SerializeField] int[,] bateriasCollected;
    [SerializeField] int bateriasAtivas;
    void Start()
    {
        timeBateria = 180f;
        timeBateriaAtual = timeBateria;
        bateriaGO.SetActive(false);
    }
    void Update()
    {
        if(lanternaGO.enabled == true)
        {
            timeBateria -= Time.deltaTime;
            bateriaGO.SetActive(true);
        }
        verifierBateriaTime();
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
        else if(timeBateria <= 0 && bateriasAtivas == 2)
        {
            fullEnergy.SetActive(false);
            mediumEnergy.SetActive(false);
            lowEnergy.SetActive(false);
            bateriasAtivas = 0;
        }
    }
}
