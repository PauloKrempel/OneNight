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

        [Header("Pilha")]
        public bool pilha = false;
        [Header("Fita")]
        public bool fita = false;
        [Header("Gravador")]
        public bool gravador = false;
        [Header("Chave Porão")]
        public bool chavePorao = false;
        
        [Header("Layer em contato")]
        private LayerMask LayerEnemy;
        private LayerMask LayerPlayer;
        private LayerMask LayerLavanderia;
        private LayerMask LayerBanheiro;
        private LayerMask LayerPorao;
        private LayerMask LayerSaida;
        private LayerMask LayerGaveta;
        private LayerMask LayerPilha;
        private LayerMask LayerFita;
        private LayerMask LayerGravador;
        private LayerMask LayerChavePorao;

        void Start() {
            LayerEnemy = LayerMask.GetMask("portaE");
            LayerPlayer = LayerMask.GetMask("Interact");
            LayerLavanderia = LayerMask.GetMask("portaL");
            LayerBanheiro = LayerMask.GetMask("Interact");
            LayerPorao = LayerMask.GetMask("portaPo");
            LayerSaida = LayerMask.GetMask("portaSaida");
            LayerGaveta = LayerMask.GetMask("gaveta");
            LayerPilha = LayerMask.GetMask("pilha");
            LayerFita = LayerMask.GetMask("fita");
            LayerGravador = LayerMask.GetMask("gravador");
            LayerChavePorao = LayerMask.GetMask("chavePorao");
        }
        public void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;
            Verificadores();

            if(Physics.Raycast(transform.position, fwd, out hit, rayLength / 4, mask)){
                if(!doOnce)
                {
                    raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                    CrosshairChange(true);
                }
                isCrosshairActive = true;
                doOnce = true;
                if(Input.GetKeyDown(openDoorKey))
                {
                    raycastedObject.ObjectInteraction();
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
            verifierGravador();
            verifierFita();
        }
        void verifierFita()
        {
            RaycastHit hitLayer;
            if (Physics.Raycast(transform.position, transform.forward, out hitLayer, rayLength, LayerFita))
            {
                fita = true;
            }
            else
            {
                fita = false;
            }
        }
        void verifierGravador()
        {
            RaycastHit hitLayer;
            if (Physics.Raycast(transform.position, transform.forward, out hitLayer, rayLength, LayerGravador))
            {
                gravador = true;
            }
            else
            {
                gravador = false;
            }
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
            }
            else
            {
                gaveta01 = false;
            }
        }
        void verifierChavePorao()
        {
            RaycastHit hitLayer;
            if (Physics.Raycast(transform.position, transform.forward, out hitLayer, rayLength, LayerChavePorao))
            {
                chavePorao = true;
            }
            else
            {
                chavePorao = false;
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

