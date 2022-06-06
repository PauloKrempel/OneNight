using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [Header("Portal")]
    [SerializeField] AudioSource portaAbrindo;
    [SerializeField] AudioSource portaFechando;
    [SerializeField] AudioSource portaFechada;

    [Header("Passos")]
    [SerializeField] AudioSource pisoMadeira;
    [SerializeField] AudioSource pisoCimento;
    [Header("Fitas")]
    [SerializeField] AudioSource fitaUM;
    [SerializeField] AudioSource fitaDOIS;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.H))
        {
            if(fitaUM.isPlaying == true)
            {
                fitaUM.Pause();
            }
            else{
                fitaUM.Play();
            }
        }
    }

    public void PlayPortaAbrindo()
    {
        portaAbrindo.Play();
    }
    public void PlayPortaFechada()
    {
        portaFechada.Play();
    }

}
