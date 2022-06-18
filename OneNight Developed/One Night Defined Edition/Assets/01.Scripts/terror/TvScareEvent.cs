using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NarrativeSystem;

public class TvScareEvent : MonoBehaviour
{
    public Narrative _narrative;
    public Material noiseTexture;
    public Material deafutTextureTV;
    public AudioClip noiseSoundClip;
    public float scareTime = 10f;

    [SerializeField] Light tvLight;

    bool showScare = false;
    AudioSource source;
    [SerializeField] Renderer tvMaterial;
    float scrollSpeed = 0.5f;

    void Start()
    {
        source = GetComponent<AudioSource>();
        tvLight.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") && _narrative.apagarLuzes)
        {
            source.clip = noiseSoundClip;
            tvMaterial.material = noiseTexture;
            source.Play();
            source.loop = true;
            tvLight.enabled = true;
            showScare = true;
        }
    }
    
    void Update()
    {
        if(showScare)
        {
            float offset = Time.time * scrollSpeed;
            tvMaterial.material.mainTextureOffset = new Vector2(offset / Time.deltaTime, -offset);
            scareTime -= Time.deltaTime;
            if(scareTime <= 0)
            {
                source.Stop();
                source.loop = false;
                showScare = false;
                tvMaterial.material = deafutTextureTV;
                tvLight.enabled = false;
            }
        }
    }
}
