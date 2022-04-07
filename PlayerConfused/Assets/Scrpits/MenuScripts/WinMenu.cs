using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    void Start()
    {

    }
    public void OnMainMenuClicked()
    {
        Debug.Log("MainMenu clicked");
        SceneManager.LoadScene(0);
    }
}
