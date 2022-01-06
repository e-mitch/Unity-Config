using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownControls : MonoBehaviour
{
    private List<string> dropdownValues = new List<string>();
    Dropdown dropdown;
    public GameObject tabletopObject;
    private int selectedIndex;
    private TabletopControls tabletopControls;
    private List<List<float>> generatedDimensions;

    
    void Start()
    {
        tabletopControls = tabletopObject.GetComponent<TabletopControls>();
        generatedDimensions = CreateValues();
        PopulateValues(generatedDimensions);
        
    }

    //Get value pairs from active table GameObject
    private List<List<float>> CreateValues()
    {
        return tabletopControls.CreateDimensionPairs();
    }

    void Update()
    {
        
    }

    //Format and populate values in dropdown
    public void PopulateValues(List<List<float>> dimensions)
    {
        dropdown = gameObject.GetComponent<Dropdown>();
        dropdown.ClearOptions();
        foreach (List<float> pair in generatedDimensions)
        {
            string currentPair = pair[0] * 100f + "x" + pair[1] * 100f + "cm";
            dropdownValues.Add(currentPair);
        }

        foreach (string item in dropdownValues)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
        }
        dropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(dropdown);
        });

    }

    //When dropdown value is changed, calls tabletop's updateDimensions function
    void DropdownValueChanged(Dropdown change)
    {
        selectedIndex = change.value;
        tabletopControls.updateDimensions(generatedDimensions[selectedIndex]);
    }
        
 }
