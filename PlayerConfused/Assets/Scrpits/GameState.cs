using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public delegate void VisionChanged(bool visionState);
    public static event VisionChanged OnVisionChanged;
    public int score = 0;
    int wormCount;

    public bool vision = false;

    public GameObject winscreen;
    public GameObject wormsLeftScreen;

    private void Start()
    {
        wormCount = FindObjectsOfType<EnemyAI>().Length;
        UpdateWormCount();
    }

    public void ToggleVision()
    {
        vision = !vision;
        if (OnVisionChanged != null)
        {
            OnVisionChanged(vision);
        }
    }

    public void SetVision(bool on)
    {
        if (vision != on)
        {
            ToggleVision();
        }
    }

    public void ScorePoint()
    {
        score += 1;
        wormCount -= 1;
        if (wormCount <= 0)
        {
            WinGame();
        }
        else
        {
            UpdateWormCount();
        }
    }

    void WinGame()
    {
        Debug.Log("Win Game called");
        Debug.Assert(winscreen, "No win screen found!");
        winscreen.SetActive(true);
        FindObjectOfType<GameState>().SetVision(true);
        HideWormCount();
    }

    void UpdateWormCount()
    {
        Debug.Assert(wormsLeftScreen, "No worms left screen!");
        wormsLeftScreen.GetComponentInChildren<UnityEngine.UI.Text>().text = wormCount.ToString() + " worms left";
    }

    void HideWormCount()
    {
        wormsLeftScreen.SetActive(false);
    }
}
