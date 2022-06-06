using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorControler : MonoBehaviour
    {
        private Animator doorAnim;
        bool doorOpen = false;

        [Header("Animations Name")]
        [SerializeField] string openAnimationName = "DoorOpen";
        [SerializeField] string closeAnimationName = "DoorClose";

        // [SerializeField] int timeToShowUI = 1;
        // [SerializeField] GameObject showDoorLockedUI = null;
        [SerializeField] KeyInventory _keyInventory = null;
        [SerializeField] int waitTimer = 1;
        [SerializeField] bool pauseInteraction = false;
        [SerializeField] SoundController som;

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
            if(_keyInventory.hasKeyQP)
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

