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
                string partName = hit.transform.name;

                if (partName.Contains("Gear1"))
                {
                    ShowInfo("Gear 1",
                        "This is the driving gear. It transfers rotational motion to Gear 2.");
                }
                else if (partName.Contains("Gear2"))
                {
                    ShowInfo("Gear 2",
                        "This is the driven gear. It receives rotational motion from Gear 1.");
                }
                else if (partName.Contains("Shaft"))
                {
                    ShowInfo("Shaft",
                        "A shaft supports and transfers rotational motion between mechanical components.");
                }
                else if (partName.Contains("Hub1"))
                {
                    ShowInfo("Hub 1",
                        "The hub connects Gear 1 to its shaft.");
                }
                else if (partName.Contains("Hub2"))
                {
                    ShowInfo("Hub 2",
                        "The hub connects Gear 2 to its shaft.");
                }
                else if (partName.Contains("Bolt"))
                {
                    ShowInfo("Bolt",
                        "Bolts fasten mechanical components together and help keep them securely connected.");
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

