using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownControls : MonoBehaviour
{
    private List<string> dropdownValues = new List<string>();
    Dropdown dropdown;
    private int selectedIndex;
    private TabletopControls tabletopControls;
    public List<List<float>> generatedDimensions;
    public GameObject activeObject;
    public bool filled = false;

   
    //Format and populate values in dropdown
    public void PopulateValues()
    {
        tabletopControls = activeObject.GetComponent<TabletopControls>();
        dropdown = gameObject.GetComponent<Dropdown>();
        if (!filled)
        {
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
        
        filled = true;

    }


    //When dropdown value is changed, calls tabletop's updateDimensions function
    void DropdownValueChanged(Dropdown change)
    {
        selectedIndex = change.value;
        tabletopControls.updateDimensions(generatedDimensions[selectedIndex]);
    }
        
 }
