using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAparicao : MonoBehaviour
{
    [Header("Pré-Requisitos")] [Tooltip("Requesitos para as aparições")]
    [SerializeField] int keys;
    [SerializeField] int tapes;

    [Header("Caracteristicas Raycast")]
    [SerializeField] [Range(0f,50f)] [Tooltip("Range do raio que detectará o enemy")] float rayLength = 40f;
    [SerializeField] LayerMask layerMaskInteract;
    [SerializeField] string excluseLayerName = null;

    [Header("Enemy")][Tooltip("Aparição dos Inimigos")]
    [SerializeField] GameObject enemySalaTOCozinha;
    [SerializeField] Animator enemySalaTOCozinhaAnim;

    void Start()
    {
        
        enemySalaTOCozinha.SetActive(false);
    }
    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;
        if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask) && tapes >= 2)
        {
            if(hit.collider.CompareTag("CorredorSala"))
            {
                enemySalaTOCozinha.SetActive(true);
                enemySalaTOCozinhaAnim.SetBool("andar", true);
                StartCoroutine(enemySalaTOCozinhaDesable());
            }
        }
        Debug.DrawRay(transform.position, fwd * rayLength, Color.white );
        if(Input.GetKeyDown(KeyCode.K))
        {
            tapes++;
        }
    }
    IEnumerator enemySalaTOCozinhaDesable()
    {
        yield return new WaitForSeconds(5);
        enemySalaTOCozinha.SetActive(false);
        StopCoroutine(enemySalaTOCozinhaDesable());
    }
}
