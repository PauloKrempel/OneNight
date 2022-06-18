using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using FearSystem;

public class ChangeVolume : MonoBehaviour
{
    [Header("Volume")]
    [SerializeField] Volume volumeFear;
    [SerializeField] Volume volumeEmotion;
    [SerializeField] Volume volumeEmotionTransition;
    [SerializeField] Volume pisqueVolume;

    [Header("Som")]
    [SerializeField] AudioSource heartSound;
    [Header("Config")]
    public RayAparicao _rayFear;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (heartSound.isPlaying)
        {
            volumeFear.priority = 0;
            volumeEmotion.priority = 2;
            StartCoroutine(changeEmotionVolume());
        }
        else
        {
            volumeFear.priority = 2;
            volumeEmotion.priority = 0;
            volumeEmotionTransition.priority = 0;
        }
        // if (_rayFear.pisque)
        // {
        //     StartCoroutine(pisquePlayer());
        //     _rayFear.pisque = false;
        // }
        // else
        // {
        //     volumeFear.priority = 2;
        //     pisqueVolume.priority = 0;
        // }

    }
    IEnumerator pisquePlayer()
    {
        volumeFear.priority = 0;
        pisqueVolume.priority = 2;
        yield return new WaitForSeconds(0.5f);
        volumeFear.priority = 2;
        pisqueVolume.priority = 0;
        StopCoroutine(pisquePlayer());
    }
    IEnumerator changeEmotionVolume()
    {
        yield return new WaitForSeconds(0.5f);
        volumeEmotionTransition.priority = 2;
        volumeEmotion.priority = 0;
        yield return new WaitForSeconds(0.5f);
        volumeEmotionTransition.priority = 0;
        volumeEmotion.priority = 2;
        yield return new WaitForSeconds(0.5f);
        volumeEmotionTransition.priority = 2;
        volumeEmotion.priority = 0;
        yield return new WaitForSeconds(0.5f);
        volumeEmotionTransition.priority = 0;
        volumeEmotion.priority = 2;
        yield return new WaitForSeconds(0.5f);
        volumeEmotionTransition.priority = 2;
        volumeEmotion.priority = 0;
        yield return new WaitForSeconds(0.5f);
        volumeEmotionTransition.priority = 0;
        volumeEmotion.priority = 2;
        yield return new WaitForSeconds(0.5f);
        volumeEmotionTransition.priority = 2;
        volumeEmotion.priority = 0;
        yield return new WaitForSeconds(0.5f);
        volumeEmotionTransition.priority = 0;
        volumeEmotion.priority = 2;
        yield return new WaitForSeconds(0.5f);
        volumeEmotionTransition.priority = 2;
        volumeEmotion.priority = 0;
        yield return new WaitForSeconds(0.5f);
        volumeFear.priority = 2;
        volumeEmotion.priority = 0;
        volumeEmotionTransition.priority = 0;
        StopCoroutine(changeEmotionVolume());

    }
}
