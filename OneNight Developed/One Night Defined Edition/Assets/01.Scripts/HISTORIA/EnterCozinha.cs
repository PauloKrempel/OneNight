using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NarrativeSystem
{
    public class EnterCozinha : MonoBehaviour
    {
        public Narrative _narrative;
        public bool cozinhaActive = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (!cozinhaActive)
                {
                    _narrative.entrouNaCozinha = true;
                    cozinhaActive = true;
                }
            }
        }
    }
}

