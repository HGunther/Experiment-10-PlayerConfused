using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    public void OnPausePressed()
    {
        Debug.Log("Pause pressed");
        Time.timeScale = 0.0f;
        gameObject.SetActive(true);
    }

    public void OnResumeClicked()
    {
        Debug.Log("Resume clicked");
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    public void OnMainMenuClicked()
    {
        Debug.Log("MainMenu clicked");
        SceneManager.LoadScene(0);
    }
}
