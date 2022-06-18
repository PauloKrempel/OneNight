using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NarrativeSystem;
public class discargaPlay : MonoBehaviour
{
    public AudioSource descarga;
    public AudioSource tosseEnemy;
    public AudioSource heartSound;
    public bool onDescarga = false;
    [SerializeField] Narrative _narrative;
    private void Update() {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _narrative.entrouNaCozinha)
        {
            if (!descarga.isPlaying && !onDescarga)
            {
                StartCoroutine(darDescarga());
                onDescarga = true;
            }
        }
    }
    IEnumerator darDescarga()
    {
        yield return new WaitForSeconds(5f);
        descarga.Play();
        heartSound.Play();
        yield return new WaitForSeconds(1.5f);
        tosseEnemy.Play();
        StopCoroutine(darDescarga());
    }
}
