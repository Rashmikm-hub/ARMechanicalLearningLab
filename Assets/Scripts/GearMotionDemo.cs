using UnityEngine;

public class GearMotionDemo : MonoBehaviour
{
    public GearRotation gear1;
    public GearRotation gear2;

    public void StartDemonstration()
    {
        gear1.ResumeRotation();
        gear2.ResumeRotation();

        Debug.Log("Gear motion demonstration started!");
    }

    public void StopDemonstration()
    {
        gear1.PauseRotation();
        gear2.PauseRotation();

        Debug.Log("Gear motion demonstration stopped!");
    }
}