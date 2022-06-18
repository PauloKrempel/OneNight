using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Pause Screen")]
    [SerializeField] GameObject pauseScreenGO;
    void Awake(){
        instance = this;
    }
    void Start(){
        pauseScreenGO.SetActive(false);
    }
    
    public void goMenu(string cena)
    {
        SceneManager.LoadScene(cena);
    }
    public void PauseGame()
    {
        pauseScreenGO.SetActive(true);
    }
    public void PauseGameOFF()
    {
        pauseScreenGO.SetActive(false);
    }
}
