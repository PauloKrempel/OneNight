using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NarrativeSystem;

namespace FearSystem
{
    public class RayAparicao : MonoBehaviour
    {
        //Volume _volume;
        [Header("Pré-Requisitos")]
        [Tooltip("Requesitos para as aparições")]
        [SerializeField] int keys;
        [SerializeField] int tapes;
        [SerializeField] bool enabledTrigger = false;
        [SerializeField] Light lanterna;
        [SerializeField] Narrative _narative;
        [SerializeField] float timerFear = 17f;

        [Header("Caracteristicas Raycast")]
        [SerializeField][Range(0f, 50f)][Tooltip("Range do raio que detectará o enemy")] float rayLength = 40f;
        [SerializeField][Range(0f, 50f)][Tooltip("Range do raio que detectará o enemy")] float rayLengthSaida = 40f;
        [SerializeField] LayerMask layerMaskInteract;
        [SerializeField] string excluseLayerName = null;

        [Header("Trigger Set")]
        TriggerRay _triggerSet;
        public int triggerGet;
        public int triggerAtual = 0;
        public bool pisque = false;
        public bool triggerON = false;
        [Header("Som")]
        [SerializeField] AudioSource heartSound;

        [Header("Enemy")]
        [Tooltip("Aparição dos Inimigos")]
        [Header("01: Andando na Cozinha")]
        [SerializeField] GameObject enemySalaTOCozinha;
        [SerializeField] Animator enemySalaTOCozinhaAnim;
        [SerializeField] AudioSource eSTCozinha;
        [Header("02: Saida da casa")]
        [SerializeField] GameObject saidaPorta;
        [SerializeField] Animator saidaPortaAnim;
        [SerializeField] bool notStartSC = true;
        [SerializeField] AudioSource eSTSaida;

        [Header("03: Caminhando no Corredor")]
        [SerializeField] GameObject corredorWalk;
        [SerializeField] Animator corredorWalkAnim;
        [SerializeField] bool notStartCC = true;
        [SerializeField] AudioSource eSTCorredor;

        [Header("04: Sentado na sala")]
        [SerializeField] GameObject sentadoSala;
        [SerializeField] Animator sentadoSalaAnim;
        [SerializeField] bool notStartSS = true;
        [SerializeField] AudioSource eSTSentado;
        [SerializeField] Light luzSala;

        void Start()
        {
            enemySalaTOCozinha.SetActive(false);
            saidaPorta.SetActive(false);
            corredorWalk.SetActive(false);
            sentadoSala.SetActive(false);
            lanterna.enabled = false;
        }
        void Update()
        {
            enabledTrigger = _narative.apagarLuzes;
            if (tapes >= 2)
            {
                enabledTrigger = true;
            }

            if (triggerON)
            {
                timerFear -= Time.deltaTime;
            }
            else
            {
                timerFear = 17 + (triggerAtual * 2.5f);
            }

            if (timerFear <= 0)
            {
                triggerON = false;
            }
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;
            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask) && enabledTrigger)
            {
                triggerGet = hit.collider.gameObject.GetComponent<TriggerRay>().triggerSet;

                if (hit.collider.CompareTag("CorredorSala") && triggerGet == 1 && !triggerON && triggerAtual == 0)
                {
                    triggerAtual = 1;
                    triggerON = true;
                    enemySalaTOCozinha.SetActive(true);
                    enemySalaTOCozinhaAnim.SetBool("andar", true);
                    if (!eSTCozinha.isPlaying)
                    {
                        eSTCozinha.Play();
                    }
                    StartCoroutine(enemySalaTOCozinhaDesable());
                }
                else if (hit.collider.CompareTag("CaminhandoCorredor") && triggerGet == 3 && !triggerON && notStartCC)
                {
                    triggerAtual = 2;
                    triggerON = true;
                    if (!eSTCorredor.isPlaying)
                    {
                        eSTCorredor.Play();
                    }
                    StartCoroutine(ShowCorredorWalk());
                    notStartCC = false;
                    Debug.LogWarning("Enemy no corredor");
                }
                else if (hit.collider.CompareTag("SentadoSala") && triggerGet == 4 && !triggerON && notStartSS)
                {
                    triggerAtual = 3;
                    triggerON = true;
                    if (!eSTSentado.isPlaying)
                    {
                        eSTSentado.Play();
                        sentadoSala.SetActive(true);

                    }
                    StartCoroutine(enemySentado());
                    notStartSS = false;
                    Debug.LogWarning("Enemy no corredor");
                }
                if (hit.collider.CompareTag("SaidaCasa") && triggerGet == 2 && !triggerON && notStartSC)
                {
                    triggerAtual = 4;
                    triggerON = true;
                    if (!heartSound.isPlaying)
                    {
                        heartSound.Play();
                    }
                    if (!eSTSaida.isPlaying)
                    {
                        eSTSaida.Play();
                    }
                    StartCoroutine(ShowSaidaCasa());
                    notStartSC = false;
                    Debug.LogWarning("Enemy da porta");
                }
            }
            // if (Physics.Raycast(transform.position, fwd, out hit, rayLengthSaida, mask) && enabledTrigger && notStartSC)
            // {
            //     triggerGet = hit.collider.gameObject.GetComponent<TriggerRay>().triggerSet;

            // }
            Debug.DrawRay(transform.position, fwd * rayLength, Color.white);
            // Debug.DrawRay(transform.position, fwd * rayLengthSaida, Color.blue);
            if (Input.GetKeyDown(KeyCode.K))
            {
                tapes++;
            }
        }
        IEnumerator ShowSaidaCasa()
        {
            lanterna.enabled = true;
            saidaPorta.SetActive(true);
            saidaPortaAnim.SetTrigger("moved");
            yield return new WaitForSeconds(0.5f);
            lanterna.enabled = false;
            yield return new WaitForSeconds(0.5f);
            lanterna.enabled = true;
            yield return new WaitForSeconds(0.5f);
            lanterna.enabled = false;
            yield return new WaitForSeconds(0.5f);
            lanterna.enabled = true;
            yield return new WaitForSeconds(6.75f);
            lanterna.enabled = false;
            saidaPorta.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            triggerON = false;
            StopCoroutine(ShowSaidaCasa());

        }
        IEnumerator ShowCorredorWalk()
        {
            yield return new WaitForSeconds(4f);
            corredorWalk.SetActive(true);
            corredorWalkAnim.SetTrigger("moved");
            yield return new WaitForSeconds(2f);
            corredorWalk.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            triggerON = false;
            StopCoroutine(ShowCorredorWalk());

        }
        IEnumerator enemySentado()
        {
            yield return new WaitForSeconds(2);
            triggerON = false;
            luzSala.enabled = false;
            sentadoSala.SetActive(false);
            StopCoroutine(enemySentado());
        }
        IEnumerator enemySalaTOCozinhaDesable()
        {
            yield return new WaitForSeconds(6);
            triggerON = false;
            enemySalaTOCozinha.SetActive(false);
            StopCoroutine(enemySalaTOCozinhaDesable());
        }
    }
}

