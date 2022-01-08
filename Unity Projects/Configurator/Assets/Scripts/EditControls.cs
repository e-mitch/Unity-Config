using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditControls : MonoBehaviour
{
    public Button woodButton;
    public Button plasticButton;
    public Material woodMaterial;
    public Material plasticMaterial;
    public bool editing = false;
    public GameObject selectedGameObject;
    // Start is called before the first frame update
    void Start()
    {
        woodButton.GetComponent<Button>().onClick.AddListener(switchToWood);
        plasticButton.GetComponent<Button>().onClick.AddListener(switchToPlastic);
    }


    void switchToWood()
    {
        if (editing)
        {
            selectedGameObject.GetComponent<Renderer>().material = woodMaterial;

        }
    }

    void switchToPlastic()
    {
        if (editing)
        {
            selectedGameObject.GetComponent<Renderer>().material = plasticMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

