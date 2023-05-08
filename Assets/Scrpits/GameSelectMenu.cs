using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.WSA;

public class GameSelectMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayCreates()
    {
        SceneManager.LoadScene("Prototype 5");
    }
    public void PlayFoods()
    {
        SceneManager.LoadScene("Challenge 5");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("GameSelect");
    }
    public void QuitGame()
    {
        UnityEngine.Application.Quit();
    }
}
