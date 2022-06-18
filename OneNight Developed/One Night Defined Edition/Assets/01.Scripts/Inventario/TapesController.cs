using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NarrativeSystem;

namespace KeySystem
{
    public class TapesController : MonoBehaviour
    {
        [Header("Narrativa")]
        public Narrative _narrative;
        [SerializeField] GameObject textEntregueRemedios;
        [Header("Gravador")]
        [SerializeField] int batteryInsert = 0;
        [SerializeField] GameObject textInsertBattery;
        [SerializeField] GameObject textNoPilhas;
        public bool gravador = false;
        public bool msgGravador = false;
        [SerializeField] GameObject textNoHaveGravador;

        [Header("Tapes")]
        public bool playTapes = false;
        [SerializeField] AudioSource tapeONE;
        [SerializeField] AudioSource tapeTWO;
        [SerializeField] GameObject textPlayTape;
        [SerializeField] GameObject needTape;

        public KeyInventory _inventory;
        void Start()
        {
            textNoPilhas.SetActive(false);
            textPlayTape.SetActive(false);
            textInsertBattery.SetActive(false);
            textNoHaveGravador.SetActive(false);
            textEntregueRemedios.SetActive(false);
            needTape.SetActive(false);
        }
        void Update()
        {
            gravador = _inventory.hasGravador;
            if(gravador && !msgGravador)
            {
                StartCoroutine(showPlayTape());
                msgGravador = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && _inventory.FitasColleted > 0 && gravador && batteryInsert > 0)
            {
                playTapes = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && _inventory.FitasColleted > 0 && gravador && batteryInsert < 1)
            {
                insertBatteryOnObject();
            }
            else if(Input.GetKeyDown(KeyCode.E) && _inventory.FitasColleted > 0 && !gravador)
            {
                StartCoroutine(showNoHaveGravador());
            }
            else if(Input.GetKeyDown(KeyCode.E) && _inventory.FitasColleted < 1 && gravador)
            {
                StartCoroutine(showNeedTape());
            }

            if(Input.GetKeyDown(KeyCode.E) && batteryInsert > 0)
            {
                insertBatteryOnObject();
            }

            if (playTapes)
            {
                Debug.LogError("INDO DAR PLAY...");
                if (_inventory.FitasColleted == 1 && tapeONE.isPlaying == false)
                {
                    tapeONE.Play();
                    _narrative.deuPlayNaFitaUM = true;
                    playTapes = false;
                    Debug.LogError("PLAY NESSA KARALHA");
                }
                else if (_inventory.FitasColleted == 2 && tapeTWO.isPlaying == false && batteryInsert > 0 && !_narrative.blockPlayFitaDOIS)
                {
                    tapeTWO.Play();
                    _narrative.deuPlayNaFitaDOIS = true;
                    _narrative.pegouAFitaDOIS = true;
                    playTapes = false;
                }
                else if(_inventory.FitasColleted == 2 && tapeTWO.isPlaying == false && batteryInsert > 0 && !_narrative.blockPlayFitaDOIS)
                {
                    StartCoroutine(EntregueRemedios());
                }
            }

        }
        public void insertBatteryOnObject()
        {
            if (batteryInsert < 1 && _inventory.Pilhas > 0)
            {
                _inventory.Pilhas--;
                batteryInsert++;
                StartCoroutine(showPlayTape());
            }
            if (batteryInsert < 1 && _inventory.Pilhas < 1)
            {
                StartCoroutine(showNoPilhas());
            }
        }
        IEnumerator EntregueRemedios()
        {
            textEntregueRemedios.SetActive(true);
            yield return new WaitForSeconds(2f);
            textEntregueRemedios.SetActive(false);
            StopCoroutine(EntregueRemedios());
        }
        IEnumerator showPlayTape()
        {
            textPlayTape.SetActive(true);
            yield return new WaitForSeconds(2f);
            textPlayTape.SetActive(false);
            StopCoroutine(showPlayTape());
        }
        IEnumerator showNeedTape()
        {
            needTape.SetActive(true);
            yield return new WaitForSeconds(2f);
            needTape.SetActive(false);
            StopCoroutine(showNeedTape());
        }
        IEnumerator showNoHaveGravador()
        {
            textNoHaveGravador.SetActive(true);
            yield return new WaitForSeconds(2f);
            textNoHaveGravador.SetActive(false);
            StopCoroutine(showNoHaveGravador());
        }
        public IEnumerator showNoPilhas()
        {
            textNoPilhas.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            textNoPilhas.SetActive(false);
            StopCoroutine(showNoPilhas());
        }
    }
}

