using UnityEngine;

public class GearRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;


private float currentSpeed;
    private bool isRotating = true;

    void Start()
    {
        currentSpeed = rotationSpeed;
    }

    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.up * currentSpeed * Time.deltaTime);
        }
    }

    public void IncreaseSpeed()
    {
        currentSpeed += 25f;
    }

    public void DecreaseSpeed()
    {
        currentSpeed = Mathf.Max(0f, currentSpeed - 25f);
    }

    public void PauseRotation()
    {
        isRotating = false;
    }

    public void ResumeRotation()
    {
        isRotating = true;
    }


}
