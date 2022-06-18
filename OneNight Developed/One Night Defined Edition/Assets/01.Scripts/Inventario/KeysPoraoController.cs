using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeysPoraoController : MonoBehaviour
    {
        public GameObject textKeys; //chave coletada
        public GameObject textAllKeys; //todas as keys coletadas
        public KeyInventory _inventory; //inventario
        void Start()
        {
            textKeys.SetActive(false);
        }
        void Update()
        {
            if(_inventory.KeysPorao >= 4)
            {
                StartCoroutine(ShowTextAllKeys());
                _inventory.hasKeyPorao = true;
            }
        }
        public void showKeys()
        {
            StartCoroutine(ShowTextKeysColleted());
        }
        IEnumerator ShowTextKeysColleted()
        {
            textKeys.SetActive(true);
            yield return new WaitForSeconds(2f);
            textKeys.SetActive(false);
            StopCoroutine(ShowTextKeysColleted());
        }
        IEnumerator ShowTextAllKeys()
        {
            textKeys.SetActive(true);
            yield return new WaitForSeconds(3f);
            textKeys.SetActive(false);
            StopCoroutine(ShowTextAllKeys());
        }
    }
}

