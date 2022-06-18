using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class casaGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        inicioGame("casa");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void inicioGame(string cenaName)
    {
        SceneManager.LoadScene(cenaName);
    }
}
