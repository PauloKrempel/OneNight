using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyInventory : MonoBehaviour
    {
        public bool hasKeyQP = true; //quarto player
        public bool hasKeyBanheiro = true; //banheiro
        public bool hasKeyQE = false; //quarto enemy
        public bool hasKeyLavanderia = false; //lavanderia
        public bool hasKeyPorao = false; //porão
        public bool hasKeySaida = false; //saida
        public bool hasGravador = false; // gravador
        public bool remedios = false; //remedio
        public bool remediosEntregues = false; //
        public bool lanterna = false; //lanterna
        public int Pilhas = 0;
        public int FitasColleted = 0;
        public int KeysPorao = 0;
    }
}

