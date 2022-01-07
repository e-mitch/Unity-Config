using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletopControls : MonoBehaviour
{

    public GameObject dropdownObject;
    private Dropdown dropdown;
    private DropdownControls dropdownControls;
    private List<List<float>> dimensionPairs;
    private LegControls legControls;
    public Material selectedItemMaterial;
    public bool selected = false;
    public Material setMaterial;
    public bool doneEditing;
    private Material selectedMaterial;
    public bool hasLegs = false;

    //Set tabletop as the tabletop being used by the dropdown
    private void Start()
    {
        legControls = GetComponent<LegControls>();
        GetComponent<Renderer>().material = setMaterial;
        selectedMaterial = setMaterial;
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
                //work here to clear dropdown

            }
            GetComponent<Renderer>().material = selectedItemMaterial;
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
            Debug.Log("hit else");
            GetComponent<Renderer>().material = setMaterial;
            legControls.isSelected = false;
        }
    }

    //Make the dropdown active/visible
    private void OnMouseDown()
    {
        if (hasLegs)
        {
            dropdownObject = GameObject.FindGameObjectWithTag("dropdown");
            dropdownControls = dropdownObject.GetComponent<DropdownControls>();
            dropdownControls.activeObject = gameObject;
            dropdownControls.generatedDimensions = CreateDimensionPairs();
            dropdownControls.PopulateValues();
            selected = true;
            legControls.isSelected = true;
        }
        
    }


    //Create a list of lists where each sublist is a pair of x/z coordinates representing a possible table size
    public List<List<float>> CreateDimensionPairs()
    {
        List<List<float>> pairs = new List<List<float>>();
        pairs.Add(new List<float> { 2, 1 });
        pairs.Add(new List<float> { 2, 1.2f});
        pairs.Add(new List<float> { 2.2f, 1.2f});

        return pairs;
    }

    

    //Grow/shrink dimensions to match dropdown selection
    public void updateDimensions(List<float> newXZDimensions)
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

