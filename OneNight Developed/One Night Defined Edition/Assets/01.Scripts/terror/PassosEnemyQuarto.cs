using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassosEnemyQuarto : MonoBehaviour
{
   public AudioSource passosEnemy;
    public bool onPassos = false;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            if(!passosEnemy.isPlaying && !onPassos)
            {
                onPassos = true;
                passosEnemy.Play();
            }
        }
    }
}
