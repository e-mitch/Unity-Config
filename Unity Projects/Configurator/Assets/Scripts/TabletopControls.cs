using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Todo: don't let tables go through walls
public class TabletopControls : MonoBehaviour
{
    private DropdownControls dropdownControls;
    public List<List<float>> dimensionPairs;
    private LegControls legControls;
    public Material selectedItemMaterial;
    public bool selected = false;
    public bool doneEditing;
    public Dropdown dropdownPrefab;
    
    public bool hasLegs = false;

    //Set tabletop as the tabletop being used by the dropdown
    private void Start()
    {
        legControls = GetComponent<LegControls>();
        selected = false;
    }

    //Move the table position according to user input
    private void Update()
    {
        if (selected)
        {
            doneEditing = Input.GetKeyDown(KeyCode.Return);
            if (doneEditing)
            {
                selected = false;
                //Destroy size dropdown
                Destroy(GameObject.FindGameObjectWithTag("dropdown"));

                //Reset camera position
                CameraControls cameraControls = GameObject.Find("Main Camera").GetComponent<CameraControls>();
                cameraControls.selectedObject = null;
                cameraControls.Reset();
            }

            //Move tabletop according to keyboard input
            float moveSpeed = 0.05f;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            if(horizontalInput != 0 || verticalInput != 0)
            {
                Vector3 changeVector = new Vector3(horizontalInput * moveSpeed, 0, verticalInput * moveSpeed);
                transform.position += changeVector;
                //legControls.ShiftLegs(changeVector);
            }
        }
        else
        {
            legControls.isSelected = false;
        }
    }

    //Make the dropdown active/visible
    private void OnMouseDown()
    {
        if (hasLegs)
        {
            //Zoom in on selected object
            CameraControls cameraControls = GameObject.Find("Main Camera").GetComponent<CameraControls>();
            cameraControls.selectedObject = this.gameObject;

            //Instantiate size options dropdown and set its values
            if(GameObject.FindGameObjectsWithTag("dropdown").Length == 0)
            {
                Instantiate(dropdownPrefab, GameObject.Find("EditTools").transform);
                dropdownControls = GameObject.FindGameObjectWithTag("dropdown").GetComponent<DropdownControls>();
                dropdownControls.activeObject = gameObject;
                dropdownControls.generatedDimensions = dimensionPairs;
                dropdownControls.PopulateValues();
            }
            

            selected = true;
            legControls.isSelected = true;

            //Tells edit controls what object is being edited
            EditControls editControls = GameObject.Find("EditTools").GetComponent<EditControls>();
            editControls.editing = true;
            editControls.selectedGameObject = this.gameObject;
        }
        
    }


    //Grow/shrink dimensions to match dropdown selection
    public void UpdateDimensions(List<float> newXZDimensions)
    {
        float newX = newXZDimensions[0];
        float newZ = newXZDimensions[1];
        Vector3 newDims = new Vector3(newX, transform.localScale.y, newZ);
        float growRate = 0.01f;
        
        if (transform.localScale.x < newDims.x)
        {
            while (transform.localScale.x <= newDims.x)
            {
                transform.localScale += new Vector3(growRate, 0, 0);
            }
        }
        else if (transform.localScale.x >= newDims.x)
        {
            while (transform.localScale.x >= newDims.x)
            {
                transform.localScale -= new Vector3(growRate, 0, 0);
            }
        }
        if (transform.localScale.z < newDims.z)
        {
            while (transform.localScale.z <= newDims.z)
            {
                transform.localScale += new Vector3(0, 0, growRate);
            }
        }
        else if (transform.localScale.z >= newDims.z)
        {
            while (transform.localScale.z >= newDims.z)
            {
                transform.localScale -= new Vector3(0, 0, growRate);
            }
        }
        legControls.UpdateLegPositions();
    }
}

