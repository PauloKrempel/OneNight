using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FearSystem;

namespace KeySystem
{
    public class KeyDoorControler : MonoBehaviour
    {
        private Animator doorAnim;
        bool doorOpen = false;
        public bool freeAcess = false;

        [Header("Animations Name")]
        [SerializeField] string openAnimationName = "DoorOpen";
        [SerializeField] string closeAnimationName = "DoorClose";

        // [SerializeField] int timeToShowUI = 1;
        // [SerializeField] GameObject showDoorLockedUI = null;
        [SerializeField] KeyInventory _keyInventory = null;
        [SerializeField] int waitTimer = 1;
        [SerializeField] bool pauseInteraction = false;
        [SerializeField] SoundController som;
        public LockedDoor lockedDoorSystem;

        private void Awake()
        {
            doorAnim = GetComponent<Animator>();
        }

        IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }
        public void PlayAnimation()
        {
            if(_keyInventory.hasKeyQE || freeAcess)
            {
                if(!doorOpen && !pauseInteraction)
                {
                    doorAnim.SetTrigger("openDoor");
                    doorOpen = true;
                    som.PlayPortaAbrindo();
                    StartCoroutine(PauseDoorInteraction());
                }
                else if(doorOpen && !pauseInteraction)
                {
                    doorAnim.SetTrigger("openDoor");
                    doorOpen = false;
                    StartCoroutine(PauseDoorInteraction());
                }
                else
                {
                    som.PlayPortaFechada();
                }
            }
            else
            {
                som.PlayPortaFechada();
                if(lockedDoorSystem != null)
                {
                    lockedDoorSystem.ShowTextLocked();
                }
                
            }
            
        }
        // IEnumerator ShowDoorLocked()
        // {
        //     showDoorLockedUI.SetActive(true);
        //     yield return new WaitForSeconds(timeToShowUI);
        //     showDoorLockedUI.SetActive(false);
        // }
    }
}

