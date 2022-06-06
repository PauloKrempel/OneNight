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

        [Header("Inventario")]
        [SerializeField] KeyInventory _keyInventory = null;
        KeyDoorControler doorObject;
        [SerializeField] int Pilhas;

        private void Start() {
            if(qpDoor)
            {
                doorObject = GetComponent<KeyDoorControler>();
            }

        }
        private void Update() {
            EnemyDoor = keyRay.EnemyDoor;
            LivreDoor = keyRay.banheiroDoor || keyRay.PlayerDoor;
            lavanderiaDoor = keyRay.lavanderiaDoor;
            poraoDoor = keyRay.poraoDoor;
            saidaDoor = keyRay.saidaDoor;
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

        }
        public void MorePilha()
        {
            _keyInventory.Pilhas++;
        }
    }
}

