using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject wormCounter;

    void Start()
    {
        Debug.Assert(wormCounter, "No worm counter in the pause menu controller - pausing will not be handled properly");
    }

    public void OnPausePressed()
    {
        Debug.Log("Pause pressed");
        Time.timeScale = 0.0f;
        gameObject.SetActive(true);
        wormCounter.SetActive(false);
    }

    public void OnResumeClicked()
    {
        Debug.Log("Resume clicked");
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
        wormCounter.SetActive(true);
    }

    public void OnMainMenuClicked()
    {
        Debug.Log("MainMenu clicked");
        SceneManager.LoadScene(0);
    }
}
