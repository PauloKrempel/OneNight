using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickLight : MonoBehaviour
{
    public float minTimer = 0.05f;
    public float maxTimer = 1.2f;

    float timer;
    Light lightFlick;
    void Start()
    {
        lightFlick = GetComponent<Light>();
        timer = Random.Range(minTimer, maxTimer);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;  
        if(timer <= 0){
            lightFlick.enabled = !lightFlick.enabled;
            timer = Random.Range(minTimer, maxTimer);
        }
    }
}
