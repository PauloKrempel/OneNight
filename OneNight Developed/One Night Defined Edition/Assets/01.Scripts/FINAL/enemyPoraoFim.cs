using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPoraoFim : MonoBehaviour
{
    public PlayerController _player;
    public GameObject timelineFinal;
    public bool finished = false;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") && !finished)
        {
            _player.isEnd = true;
            timelineFinal.SetActive(true);
            finished = false;
        }
    }
}
