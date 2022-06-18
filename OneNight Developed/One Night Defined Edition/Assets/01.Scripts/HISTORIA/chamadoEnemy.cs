using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NarrativeSystem;
using KeySystem;

public class chamadoEnemy : MonoBehaviour
{
    public AudioSource chamado;
    public AudioSource heartSound;
    public bool onChamado = false;
    [SerializeField] Narrative _narrative;
    [SerializeField] KeyInventory _inventory;
    [SerializeField] GameObject textMission;
    private void Start()
    {
        textMission.SetActive(false);

    }
    private void Update()
    {
        if (_inventory.FitasColleted > 1 && _narrative.entrouNoBanheiro && !onChamado)
        {
            if (!chamado.isPlaying && !onChamado)
            {
                StartCoroutine(darChamado());
                onChamado = true;
            }
        }
    }
    IEnumerator darChamado()
    {
        yield return new WaitForSeconds(2f);
        textMission.SetActive(true);
        chamado.Play();
        heartSound.Play();
        yield return new WaitForSeconds(1.5f);
        StopCoroutine(darChamado());
    }
}
