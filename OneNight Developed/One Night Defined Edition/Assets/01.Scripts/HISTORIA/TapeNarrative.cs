using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NarrativeSystem
{
    public class TapeNarrative : MonoBehaviour
    {
        [SerializeField] Narrative _narrative;
        [SerializeField] GameObject fitaDOIS;
        public bool notColleted = false;

        void Start()
        {
            fitaDOIS.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (_narrative.entrouNaCozinha && _narrative.deuPlayNaFitaUM && !notColleted)
            {
                fitaDOIS.SetActive(true);
                notColleted = true;

            }
        }
    }
}

