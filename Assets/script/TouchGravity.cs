using System.Collections;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;


public class TouchGravity : MonoBehaviour
{   

    [SerializeField]
    private GameObject placedPrefab;
    [SerializeField]
    private Button button0;

    private ARRaycastManager arRaycastManager;
    private Vector2 startPos;
    private Vector2 direction;
    private Text elementalTex;
    public GameObject arCamera;
   
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Rigidbody rigidBody;

    private Transform trans;
    private Transform trans2;
    private Vector3 pos;
    private FixedJoint fx;
    private Vector3 nowPos;
    private Quaternion nowQuaternion;

    GameObject ArCam;
    GameObject cylinder;
    GameObject gameObjectPoint;
    //GameObject NewGameObject;
    
    bool keepCylinder = true;
    int a=0;


    void FireAndGetBall()
    {
        
        keepCylinder = true;
        //nowPos = new Vector3(0, 0, 0);
        nowQuaternion = new Quaternion(0, 0, 0, 0);
        GameObject NewGameObject = Instantiate(placedPrefab, gameObjectPoint.transform.position, nowQuaternion);   // trans.postion 값 이 다르지만 생성되는 곳은 같음 - 이상함. 여기가 잘못됨.  
        Debug.Log(gameObjectPoint.transform.position);
        Debug.Log(nowPos);   // 여기 포지션 값이 잘못됐음. 고쳐야함
        trans = NewGameObject.GetComponent<Transform>();
        Rigidbody rigidBody = NewGameObject.GetComponent<Rigidbody>();
        //rigidBody.useGravity = false;

        rigidBody.isKinematic = false;
        rigidBody.useGravity = true;
        rigidBody.AddForce(arCamera.transform.forward * 200);
        //KeepCylinder();
        a++;
    }

    void TouchGravityForce()
    {
        Debug.Log("a");
      
            keepCylinder = false;
                
                //gameObjectPoint.transform.DetachChildren();
        //        rigidBody.isKinematic = false;
        //        rigidBody.useGravity = true;
               // Quaternion rotation = trans.rotation;
               // rotation.eulerAngles = new Vector3(trans.rotation.x, trans.rotation.y+30, trans.rotation.z);

       //        rigidBody.AddForce(Vector3.forward * 200);
               //rigidBody.AddForce(0, 1, 1);trans.forward
               Invoke("NewGameObjectIn", 0);
               // NewGameObjectIn();


    }

  

    void KeepCylinder()
    {
        if (keepCylinder)
        {
           // rigidBody.isKinematic = true;
           
            //placedPrefab.transform.SetParent(gameObjectPoint.transform);
            if (a > 0)
            {
               //NewGameObject.transform.SetParent(gameObjectPoint.transform);
            }

           // trans.localPosition = new Vector3(0, 0, 0);
          //  trans.position = gameObjectPoint.transform.position;
            trans.rotation = ArCam.transform.rotation;
            //Debug.Log(gameObjectPoint.transform.position);
        }
    }


    void Awake()
    {
        
        rigidBody = placedPrefab.GetComponent<Rigidbody>();
        trans = placedPrefab.GetComponent<Transform>();
        ArCam = GameObject.Find("AR Camera");
        cylinder = GameObject.Find("Cylinder");
        gameObjectPoint = GameObject.Find("GameObjectPoint");
        // button0 = transform.GetComponent<Button>();
        button0.onClick.AddListener(FireAndGetBall);

        
    }
   

    void Update()
    {

      
        //KeepCylinder();
     
    }


}
