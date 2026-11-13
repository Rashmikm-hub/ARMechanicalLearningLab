using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePageManager : MonoBehaviour
{
    public void OpenGearSystem()
    {
        SceneManager.LoadScene("ARMechanicalScene");
    }
}