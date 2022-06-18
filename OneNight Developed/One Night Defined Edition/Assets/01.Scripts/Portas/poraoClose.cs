using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeySystem;

public class poraoClose : MonoBehaviour
{
    public KeyInventory _inventory;
    [SerializeField] bool OnEnterPorao = false;
    public Animator animPortaPorao;
    public AudioSource atrasdeVoce;
    [SerializeField] GameObject enemyQuarto;

    private void Start()
    {
        enemyQuarto.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !OnEnterPorao)
        {
            _inventory.KeysPorao = 0;
            _inventory.hasKeyQE = false;
            if (!atrasdeVoce.isPlaying)
            {
                atrasdeVoce.Play();
                enemyQuarto.SetActive(true);
                animPortaPorao.SetTrigger("openDoor");

            }
            OnEnterPorao = true;
        }
    }
}
