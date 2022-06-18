using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [Header("Interação")]
        [SerializeField] int LayerInterativa;
        [SerializeField] KeyRaycast keyRay;

        [Header("Portas")]
        public bool EnemyDoor = false;
        public bool LivreDoor = false; //quarto player e banheiro
        public bool lavanderiaDoor = false;
        public bool poraoDoor = false;
        public bool saidaDoor = false;

        [Header("Ambientes livres")]
        [SerializeField] bool qpDoor = false;
        [SerializeField] bool bDoor = false;
        [SerializeField] bool keyQP = false;

        [Header("Quarto Enemy")]
        [SerializeField] bool qeDoor = false;
        [SerializeField] bool keyQE = false;
        public LockedDoor lockedDoorSystem;

        [Header("CHAVES")]
        [SerializeField] bool iAmKey = false;
        public int keysColleted = 0;

        [Header("pilha")]
        [SerializeField] bool iAmPilha = false;
        [Header("Fita")]
        [SerializeField] bool iAmFita = false;
        [Header("Gravador")]
        [SerializeField] bool iAmGravador = false;

        [Header("Inventario")]
        [SerializeField] KeyInventory _keyInventory = null;
        public KeyDoorControler doorObject;
        [SerializeField] int Pilhas;
        [Header("Gaveta")]
        [SerializeField] bool iAmGaveta = false;
        public Animator anim;
        [Header("Remedio")]
        [SerializeField] bool iAmRemedio = false;
        [SerializeField] bool depositRemedio = false;
        [SerializeField] MeshRenderer renderRemedio;
        [Header("Lanterna")]
        [SerializeField] bool iLanterna = false;

        private void Start() {
            if(iAmGaveta)
            {
                anim = GetComponent<Animator>();
            }
            if(qpDoor)
            {
                doorObject = GetComponent<KeyDoorControler>();
            }
            if(depositRemedio)
            {
                renderRemedio = GetComponent<MeshRenderer>();
                renderRemedio.enabled = false;
            }

        }
        private void Update() {
            EnemyDoor = keyRay.EnemyDoor;
            LivreDoor = keyRay.banheiroDoor || keyRay.PlayerDoor;
            lavanderiaDoor = keyRay.lavanderiaDoor;
            saidaDoor = keyRay.saidaDoor;
            keyQE = _keyInventory.hasKeyQE;
            if(Input.GetKeyDown(KeyCode.Alpha5))
            {
                
                _keyInventory.KeysPorao++;
                Debug.LogError("Chave quarto enemy no inventario");
            }
        }
        public void ObjectInteraction()
        {
            if(qpDoor)
            {
                doorObject.PlayAnimation();
            }
            else if(keyQP)
            {
                _keyInventory.hasKeyQP = true;
                gameObject.SetActive(false);
            }
            else if(iAmPilha)
            {
                _keyInventory.Pilhas++;
                gameObject.SetActive(false);
            }
            else if(iAmFita)
            {
                _keyInventory.FitasColleted++;
                gameObject.SetActive(false);
            }
            else if(iAmGravador)
            {
                _keyInventory.hasGravador = true;
                gameObject.SetActive(false);
            }
            else if(iAmGaveta)
            {
                anim.SetTrigger("open");
            }
            else if(iAmKey)
            {
                _keyInventory.KeysPorao++;
                gameObject.SetActive(false);
            }
            else if(poraoDoor || qeDoor)
            {
                if(_keyInventory.KeysPorao >= 4 && _keyInventory.hasKeyQE == false)
                {
                    _keyInventory.hasKeyQE = true;
                }
                else{
                    doorObject.PlayAnimation();
                }
            }
            else if(iAmRemedio)
            {
                _keyInventory.remedios = true;
                gameObject.SetActive(false);
            }
            else if(depositRemedio && _keyInventory.remedios)
            {
                renderRemedio.enabled = true;
                _keyInventory.remediosEntregues = true;
                _keyInventory.remedios = false;
            }
            else if(iLanterna)
            {
                _keyInventory.lanterna = true;
                gameObject.SetActive(false);
            }
        }
    }
}

