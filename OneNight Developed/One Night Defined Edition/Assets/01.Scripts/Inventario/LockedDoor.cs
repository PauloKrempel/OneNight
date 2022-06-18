using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class LockedDoor : MonoBehaviour
    {
        [SerializeField] GameObject textLockedDoor;
        void Start()
        {
            textLockedDoor.SetActive(false);

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void ShowTextLocked()
        {
            StartCoroutine(ShowDoorLocked());
        }
        IEnumerator ShowDoorLocked()
        {
            textLockedDoor.SetActive(true);
            yield return new WaitForSeconds(2f);
            textLockedDoor.SetActive(false);
            StopCoroutine(ShowDoorLocked());
        }
    }
}
