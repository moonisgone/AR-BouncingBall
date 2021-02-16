using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;
//using UnityEngine.XR.ARSubsystems;
//using TrackableType = UnityEngine.XR.ARSubsystems.TrackableType;

public class TouchPointGravity : MonoBehaviour
{

    [SerializeField]
    private GameObject placedPrefab;

    private ARRaycastManager arRaycastManager;
    private Vector2 startPos;
    private Vector2 direction;

    //private Vector2 touchPosition = default;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Rigidbody rigidBody;
    private Transform trans;
    private Vector3 pos;
    void Awake()
    {
       
    }

    void Update()
    {

    
         

    }


}
