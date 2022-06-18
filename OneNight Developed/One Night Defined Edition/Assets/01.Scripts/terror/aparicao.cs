using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aparicao : MonoBehaviour
{
    [Header("Stages")]
    [SerializeField] public int keysCollected;
    [SerializeField] public int tapesCollected;

    [Header("Aparição")]
    [SerializeField] GameObject apar;
    [SerializeField] float timer = 3;
    public bool aparInGame = false;

    void Start()
    {
        apar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(aparInGame)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            aparInGame = false;
            apar.SetActive(false);
            timer = 3f;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(tapesCollected == 2 && other.CompareTag("Player"))
        {
            apar.SetActive(true);
            aparInGame = true;
        }
    }
}
