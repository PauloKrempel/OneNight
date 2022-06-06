using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trovao : MonoBehaviour
{
    public float minTimer = 10f;
    public float maxTimer = 45f;

    float timer;
    [SerializeField] AudioSource trovaoSound;
    void Start()
    {
        timer = Random.Range(minTimer, maxTimer);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;  
        if(timer <= 0){
            trovaoSound.Play();
            timer = Random.Range(minTimer, maxTimer);
        }
    }
}
