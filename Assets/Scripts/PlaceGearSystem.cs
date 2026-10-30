using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class PlaceGearSystem : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject gearSystem;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (gearSystem.activeSelf)
            return;

        if (Input.touchCount > 0 &&
            Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;

            if (raycastManager.Raycast(
                touchPosition,
                hits,
                TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                gearSystem.transform.position = hitPose.position;
                gearSystem.transform.rotation = hitPose.rotation;

                gearSystem.SetActive(true);

                Debug.Log("GEAR SYSTEM PLACED!");
            }
            else
            {
                Debug.Log("NO AR PLANE DETECTED!");
            }
        }
    }
}