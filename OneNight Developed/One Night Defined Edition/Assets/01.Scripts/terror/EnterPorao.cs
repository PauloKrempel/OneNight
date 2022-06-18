using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPorao : MonoBehaviour
{
    public AudioSource poraoSource;

    [SerializeField] bool OnEnterPorao = false;
    EnterPorao myObjects;
    private void Start() {
        myObjects = GetComponent<EnterPorao>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") && !OnEnterPorao)
        {
            poraoSource.Play();
            OnEnterPorao = true;
        }
    }
}
