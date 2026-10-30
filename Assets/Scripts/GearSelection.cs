using UnityEngine;
using TMPro;

public class GearSelection : MonoBehaviour
{
    public Camera arCamera;
    public GameObject infoPanel;
    public TMP_Text infoText;


void Start()
    {
        infoPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0 &&
            Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = arCamera.ScreenPointToRay(
                Input.GetTouch(0).position
            );

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                string gearName = hit.transform.name;

                if (gearName.Contains("Gear1"))
                {
                    ShowInfo(
                        "Gear 1",
                        "This is the driving gear. It transfers rotational motion to the second gear."
                    );
                }
                else if (gearName.Contains("Gear2"))
                {
                    ShowInfo(
                        "Gear 2",
                        "This is the driven gear. It receives rotational motion from the first gear."
                    );
                }
            }
        }
    }

    void ShowInfo(string title, string description)
    {
        infoPanel.SetActive(true);
        infoText.text = title + "\n\n" + description;
    }

    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
    }

}
