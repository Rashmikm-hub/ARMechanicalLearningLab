using UnityEngine;

public class GearRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private float currentSpeed;
    private bool isRotating = true;

    private Transform gear1;
    private Transform gear2;

    void Start()
    {
        currentSpeed = rotationSpeed;

        // Find both gears
        gear1 = transform.Find("Gear1");
        gear2 = transform.Find("Gear2");

        if (gear1 == null || gear2 == null)
        {
            Debug.LogError("Gear1 or Gear2 not found!");
            return;
        }

        // Attach Gear 1 components
        AttachPart("Gear1_Shaft", gear1);
        AttachPart("Hub1", gear1);
        AttachPart("Bolt1", gear1);
        AttachPart("Bolt2", gear1);
        AttachPart("Bolt3", gear1);
        AttachPart("Bolt4", gear1);

        // Attach Gear 2 components
        AttachPart("Gear2_Shaft", gear2);
        AttachPart("Hub2", gear2);
        AttachPart("Bolt21", gear2);
        AttachPart("Bolt22", gear2);
        AttachPart("Bolt23", gear2);
        AttachPart("Bolt24", gear2);
    }

    void AttachPart(string partName, Transform gear)
    {
        Transform part = transform.Find(partName);

        if (part != null)
        {
            part.SetParent(gear, true);
        }
        else
        {
            Debug.LogWarning(partName + " not found!");
        }
    }

    void Update()
    {
        if (!isRotating || gear1 == null || gear2 == null)
            return;

        float rotation = currentSpeed * Time.deltaTime;

        gear1.Rotate(Vector3.forward, rotation, Space.Self);
        gear2.Rotate(Vector3.forward, -rotation, Space.Self);
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
