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
    public Button roundLegButton;
    public Button squareLegButton;
    public bool editing = false;
    public GameObject selectedGameObject;
    // Start is called before the first frame update
    void Start()
    {
        woodButton.GetComponent<Button>().onClick.AddListener(delegate { switchMaterial(0); });
        plasticButton.GetComponent<Button>().onClick.AddListener(delegate { switchMaterial(1); });
        roundLegButton.GetComponent<Button>().onClick.AddListener(delegate { switchLegType(0); });
        squareLegButton.GetComponent<Button>().onClick.AddListener(delegate { switchLegType(1); });
    }

    //Change material to plastic or wood
    void switchMaterial(int materialType)
    {
        if (editing)
        {
            if(materialType == 0)
            {
                selectedGameObject.GetComponent<Renderer>().material = woodMaterial;
            } else if (materialType == 1)
            {
                selectedGameObject.GetComponent<Renderer>().material = plasticMaterial;
            }
        }
    }


    //Change leg type to square or round
    void switchLegType(int legType)
    {
        GameObject[] existingLegs = GameObject.FindGameObjectsWithTag("leg");
        for(int i=0; i < existingLegs.Length; i++)
        {
            GameObject.Destroy(existingLegs[i]);
        }
        CreationControls creationControls = GameObject.Find("Room").GetComponent<CreationControls>();
        if(legType == 0)
        {
            creationControls.InstantiateRoundLegs();
        } else if (legType == 1)
        {
            creationControls.InstantiateSquareLegs();
        }
    }
}

