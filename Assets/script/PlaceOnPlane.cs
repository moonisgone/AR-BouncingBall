using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;


public class PlaceOnPlane : MonoBehaviour
{

    [SerializeField]
    public GameObject placedPrefab;
    [SerializeField]
    public Button button1;

    private GameObject placedPrefab1;

    private ARRaycastManager arRaycastManager;
    private Vector2 touchPosition = default;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    //public Button button1;
    bool _pressed = false;
    int count = 0;
    
    private ColorBlock cb;
    private Color pressedColor;
    private Color NotPressedColor;
    //public Image buttonImage;
    //public Sprite sprite;
    int a = 0;


    private void TouchOnPlane()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchPosition = touch.position;
                if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = hits[0].pose;
                    if (a == 0)
                    {
                        Quaternion rotation = Quaternion.identity;
                        rotation.eulerAngles = new Vector3(0, 90, 0);

                        placedPrefab1 = Instantiate(placedPrefab, hitPose.position, rotation);
                    }//Quaternion rotation   hitPose.rotation
                    a++;

                }

            }


        }

    }

    private void Rotation()
    {
        Touch touch = Input.GetTouch(0);
        if (Input.touchCount == 1)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                placedPrefab1.transform.Rotate(Vector3.right * 40f * Time.deltaTime * touch.deltaPosition.y, Space.Self);
            }
        }
    }

    private void ButtonClicked()
    {
       
        _pressed = !(_pressed);
       
        if (_pressed)
        {
            cb.normalColor = pressedColor;
            button1.colors = cb;
            Debug.Log(_pressed);
        }
        else
        {
            cb.normalColor = NotPressedColor;
            button1.colors = cb;
            Debug.Log(_pressed);
        }
        
    }

    private void PinchtoZoom()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

            float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
            float touchDeltaMag = (touch0.position - touch1.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            float pinchAmount = -deltaMagnitudeDiff * 0.02f * Time.deltaTime;
            placedPrefab1.transform.localScale += new Vector3(pinchAmount, pinchAmount, pinchAmount);

        }

    }



    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        button1.onClick.AddListener(ButtonClicked);
        cb = button1.GetComponent<Button>().colors;
      
        pressedColor = Color.gray;
        NotPressedColor = Color.white;
    }

    void Update()
    {   
        
        if (_pressed)
        {
            TouchOnPlane();
            Rotation();
            PinchtoZoom();
        }

     }


}
