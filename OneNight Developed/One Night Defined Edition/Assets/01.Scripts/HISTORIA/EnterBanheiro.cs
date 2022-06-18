using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NarrativeSystem
{
    public class EnterBanheiro : MonoBehaviour
    {
        public Narrative _narrative;
        public bool banheiroActive = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && _narrative.entrouNaCozinha && _narrative.deuPlayNaFitaUM)
            {
                if (!banheiroActive)
                {
                    _narrative.entrouNoBanheiro = true;
                    banheiroActive = true;
                }
            }
        }
    }
}
