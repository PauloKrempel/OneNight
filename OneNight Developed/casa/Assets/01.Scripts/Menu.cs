using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] GameObject menuGO;

    [SerializeField] GameObject opcoesGO;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void inicioGame(string cenaName)
    {
        SceneManager.LoadScene(cenaName);
    }
    public void showOptions(){
        menuGO.SetActive(false);
        opcoesGO.SetActive(true);
    }
    public void closeOptions(){
        menuGO.SetActive(true);
        opcoesGO.SetActive(false);
    }
    public void exitGame()
    {
        //editor
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    
}
