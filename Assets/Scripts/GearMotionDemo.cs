using UnityEngine;

public class GearMotionDemo : MonoBehaviour
{
    public GearRotation gearSystemRotation;

    public void StartDemonstration()
    {
        if (gearSystemRotation != null)
        {
            gearSystemRotation.ResumeRotation();
            Debug.Log("Gear motion demonstration started!");
        }
    }

    public void StopDemonstration()
    {
        if (gearSystemRotation != null)
        {
            gearSystemRotation.PauseRotation();
            Debug.Log("Gear motion demonstration stopped!");
        }
    }
}

