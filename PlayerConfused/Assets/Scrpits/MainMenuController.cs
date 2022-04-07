using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayClicked()
    {
        Debug.Log("Play clicked");
        
    }

    public void OnCreditsClicked() {
        Debug.Log("Credits clicked");
    }

    public void OnQuitClicked()
    {
        Debug.Log("Quit clicked");
        Application.Quit();
    }
}