using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator; 

    private ARRaycastManager _raycastManager;
    private Pose _placementPose;
    private bool _placementPoseIsValid = false;
    private bool _objectPlaced = false;
    private bool _gameStarted = false;

    void Start()
    {
        _raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceObject();
        }

        if (!_objectPlaced && _placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {   
            PlaceObject();
        }
    }

    private void PlaceObject()
    {
        if (_placementPoseIsValid)
        {
            Instantiate(objectToPlace, _placementPose.position, _placementPose.rotation);
            _objectPlaced = true;
        }
    }

    public void StartGame()
    {
        _gameStarted = true;
    }

    private void UpdatePlacementIndicator()
    {
        placementIndicator.SetActive(_placementPoseIsValid && !_objectPlaced);
        if (_placementPoseIsValid && !_objectPlaced)
        {
            placementIndicator.transform.SetPositionAndRotation(_placementPose.position, _placementPose.rotation);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        _raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);
 
        _placementPoseIsValid = hits.Count > 0 && !_objectPlaced;
        if (_placementPoseIsValid)
        {
            _placementPose = hits[0].pose;

            _placementPose.position += new Vector3(0, 0.1f, 0);

            var cameraForward = Camera.main.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            _placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
