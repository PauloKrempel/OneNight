using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeySystem
{
    public class KeyRaycast : MonoBehaviour
    {
        [SerializeField] float rayLength = 0.5f;
        [SerializeField] LayerMask layerMaskInteract;
        [SerializeField] string excluseLayerName = null;

        private KeyItemController raycastedObject;
        [SerializeField] KeyCode openDoorKey = KeyCode.Mouse0;
        [SerializeField] Image crosshair = null;
        [SerializeField] Animator crossAnim;
        private bool isCrosshairActive;
        private bool doOnce;
        string interactableTag = "InteractiveObject";
        [Header("Portas")]
        public bool EnemyDoor = false;
        public bool PlayerDoor = false;
        public bool lavanderiaDoor = false;
        public bool banheiroDoor = false;
        public bool poraoDoor = false;
        public bool saidaDoor = false;

        [Header("Gavetas")]
        public bool gaveta01 = false;
        [SerializeField] Animator gavetaAnim;

        [Header("Pilha")]
        public bool pilha = false;
        
        [Header("Layer em contato")]
        [SerializeField] LayerMask LayerEnemy;
        [SerializeField] LayerMask LayerPlayer;
        [SerializeField] LayerMask LayerLavanderia;
        [SerializeField] LayerMask LayerBanheiro;
        [SerializeField] LayerMask LayerPorao;
        [SerializeField] LayerMask LayerSaida;
        [SerializeField] LayerMask LayerGaveta;
        [SerializeField] LayerMask LayerPilha;

        void Start() {
            LayerEnemy = LayerMask.GetMask("portaE");
            LayerPlayer = LayerMask.GetMask("Interact");
            LayerLavanderia = LayerMask.GetMask("portaL");
            LayerBanheiro = LayerMask.GetMask("Interact");
            LayerPorao = LayerMask.GetMask("portaPo");
            LayerSaida = LayerMask.GetMask("portaSaida");
            LayerGaveta = LayerMask.GetMask("gaveta");
            LayerPilha = LayerMask.GetMask("pilha");
        }
        public void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;
            Verificadores();

            if(Physics.Raycast(transform.position, fwd, out hit, rayLength / 4, mask) && !gaveta01){
                if(!doOnce)
                {
                    raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                    CrosshairChange(true);
                }
                isCrosshairActive = true;
                doOnce = true;
                if(Input.GetKeyDown(openDoorKey))
                {
                    if(!pilha)
                    {
                        raycastedObject.ObjectInteraction();
                    }
                    else
                    {
                        raycastedObject.MorePilha();
                    }
                }
            }
            else
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }
        void Verificadores()
        {
            verifierEnemyQuarto();
            verifierPlayerQuarto();
            verifierLavanderia();
            verifierBanheiro();
            verifierPorao();
            verifierSaida();
            verifierGaveta();
        }
        void verifierEnemyQuarto()
        {
            RaycastHit hitLayer;
            if (Physics.Raycast(transform.position, transform.forward, out hitLayer, rayLength, LayerEnemy))
            {
                EnemyDoor = true;
            }
            else
            {
                EnemyDoor = false;
            }
        }
        void verifierPlayerQuarto()
        {
            RaycastHit hitLayer;
            if (Physics.Raycast(transform.position, transform.forward, out hitLayer, rayLength, LayerPlayer))
            {
                PlayerDoor = true;
            }
            else
            {
                PlayerDoor = false;
            }
        }
        void verifierLavanderia()
        {
            RaycastHit hitLayer;
            if (Physics.Raycast(transform.position, transform.forward, out hitLayer, rayLength, LayerLavanderia))
            {
                lavanderiaDoor = true;
            }
            else
            {
                lavanderiaDoor = false;
            }
        }
        void verifierBanheiro()
        {
            RaycastHit hitLayer;
            if (Physics.Raycast(transform.position, transform.forward, out hitLayer, rayLength, LayerBanheiro))
            {
                banheiroDoor = true;
            }
            else
            {
                banheiroDoor = false;
            }
        }
        void verifierPorao()
        {
            RaycastHit hitLayer;
            if (Physics.Raycast(transform.position, transform.forward, out hitLayer, rayLength, LayerPorao))
            {
                poraoDoor = true;
            }
            else
            {
                poraoDoor = false;
            }
        }
        void verifierSaida()
        {
            RaycastHit hitLayer;
            if (Physics.Raycast(transform.position, transform.forward, out hitLayer, rayLength, LayerSaida))
            {
                saidaDoor = true;
            }
            else
            {
                saidaDoor = false;
            }
        }
        void verifierGaveta()
        {
            RaycastHit hitLayer;
            if (Physics.Raycast(transform.position, transform.forward, out hitLayer, rayLength, LayerGaveta))
            {
                gaveta01 = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    gavetaAnim = hitLayer.collider.gameObject.GetComponent<Animator>();
                    gavetaAnim.SetTrigger("open");
                }
            }
            else
            {
                gaveta01 = false;
            }
        }
        void verifierPilha()
        {
            RaycastHit hitLayer;
            if (Physics.Raycast(transform.position, transform.forward, out hitLayer, rayLength, LayerPilha))
            {
                pilha = true;
            }
            else
            {
                pilha = false;
            }
        }
        void CrosshairChange(bool on)
        {
            if(on && !doOnce)
            {
                crosshair.color = Color.red;
                crossAnim.SetBool("selecionavel", true);
            }
            else
            {
                crosshair.color = Color.white;
                isCrosshairActive = false;
                crossAnim.SetBool("selecionavel", false);
            }
        }
    }
}

