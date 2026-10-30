using UnityEngine;

public class GearTeeth : MonoBehaviour
{
    public int numberOfTeeth = 12;
    public float radius = 0.43f;
    public float toothSize = 0.15f;

void Start()
    {
        for (int i = 0; i < numberOfTeeth; i++)
        {
            float angle = i * 360f / numberOfTeeth;
            float radians = angle * Mathf.Deg2Rad;

            GameObject tooth = GameObject.CreatePrimitive(PrimitiveType.Cube);

            tooth.name = "GearTooth";

            tooth.transform.SetParent(transform);

            tooth.transform.localPosition = new Vector3(
                Mathf.Cos(radians) * radius,
                0,
                Mathf.Sin(radians) * radius
            );

            tooth.transform.localRotation = Quaternion.Euler(0, -angle, 0);

            tooth.transform.localScale = new Vector3(
                toothSize,
                toothSize,
                0.15f
            );

            Destroy(tooth.GetComponent<Collider>());
        }
    }


}
