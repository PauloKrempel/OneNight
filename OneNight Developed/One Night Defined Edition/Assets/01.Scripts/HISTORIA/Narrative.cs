using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NarrativeSystem
{
    public class Narrative : MonoBehaviour
    {
        [Header("Conquistas")]
        public int desenhosEncontrados = 0;
        public bool finalTriste = false;
        public bool finalFeliz = false;

        [Header("Lvl 01")]
        public bool deuPlayNaFitaUM = false;
        public bool entrouNaCozinha = false;
        public bool entrouNoBanheiro = false;
        public bool blockPlayFitaDOIS = true;
        public bool pegouAFitaDOIS = false;

        [Header("Lvl 02")]
        public bool deuRemedios = false;
        public bool deuPlayNaFitaDOIS = false;
        public bool apagarLuzes = false;
        public int triggersAtivados = 0;

        [Header("Lvl 03")]
        public bool chaveCompleta = false;
        public bool entrouNoPorao = false;
    }
}

