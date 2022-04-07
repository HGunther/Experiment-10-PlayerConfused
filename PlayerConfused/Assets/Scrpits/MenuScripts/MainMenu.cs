using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    public void OnPlayClicked()
    {
        Debug.Log("Play clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnQuitClicked()
    {
        Debug.Log("Quit clicked");
        Application.Quit();
    }
}
