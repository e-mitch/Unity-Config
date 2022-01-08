using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject selectedObject;
    private Vector3 defaultCameraPos;
    private Vector3 defaultCameraRot;
    private float desiredXRotation = 13f;

    void Start()
    {
        selectedObject = null;
        defaultCameraPos = transform.localPosition;
        defaultCameraRot = transform.rotation.eulerAngles;
    }

    // If there is a selected object, zoom in and rotate the camera to focus on it
    void Update()
    {
       if(selectedObject != null)
        {
            transform.position = selectedObject.transform.position + new Vector3(0, 1, -4);
            if(transform.eulerAngles.x < desiredXRotation)
            {
                transform.Rotate(Vector3.right * desiredXRotation * Time.deltaTime*2);
            }
        }
    }


    //Reset the position and rotation of the camera to default
    public void Reset()
    {
        transform.position = defaultCameraPos;
        float originalXRot = 0f;
        if(transform.eulerAngles.x > originalXRot)
        {
            transform.Rotate(Vector3.right * -desiredXRotation);
        }
    }
}
