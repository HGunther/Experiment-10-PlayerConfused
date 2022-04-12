using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public delegate void VisionChanged(bool visionState);
    public static event VisionChanged OnVisionChanged;

    public bool vision = false;

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
}
