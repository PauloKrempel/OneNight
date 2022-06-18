using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextCreditos : MonoBehaviour
{
    public int timeFixedLoad = 5;
    public string credit;
    void Start()
    {
        StartCoroutine(SceneCreditos());
    }
    IEnumerator SceneCreditos()
    {
        yield return new WaitForSeconds(timeFixedLoad);
        SceneManager.LoadScene(credit);
        StopCoroutine(SceneCreditos());
    }
}
