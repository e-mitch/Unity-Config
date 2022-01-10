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
    public GameObject squareLegPrefab;
    public GameObject roundLegPrefab;
    private CreationControls creationControls;
    // Start is called before the first frame update
    void Start()
    {
        woodButton.GetComponent<Button>().onClick.AddListener(delegate { SwitchMaterial(0); });
        plasticButton.GetComponent<Button>().onClick.AddListener(delegate { SwitchMaterial(1); });
        roundLegButton.GetComponent<Button>().onClick.AddListener(delegate { SwitchLegType(0); });
        squareLegButton.GetComponent<Button>().onClick.AddListener(delegate { SwitchLegType(1); });
    }

    //Change material to plastic or wood
    void SwitchMaterial(int materialType)
    {
        if (editing)
        {
            if (materialType == 0)
            {
                selectedGameObject.GetComponent<Renderer>().material = woodMaterial;
            }
            else if (materialType == 1)
            {
                selectedGameObject.GetComponent<Renderer>().material = plasticMaterial;
            }
        }
    }

    private void Update()
    {
        if (editing)
        {
            CreationControls creationControls = GameObject.Find("Room").GetComponent<CreationControls>();
            creationControls.tablePos = selectedGameObject.transform.localPosition;
            creationControls.tableScale = selectedGameObject.transform.localScale;
        }
    }

    //Change leg type to square or round
    void SwitchLegType(int legType)
    {
        if (editing)
        {
            GameObject[] existingLegs = GameObject.FindGameObjectsWithTag("leg");
            foreach (GameObject leg in existingLegs)
            {
                GameObject.Destroy(leg);
            }
            if(legType == 0)
            {
                CreationControls creationControls = GameObject.Find("Room").GetComponent<CreationControls>();
                creationControls.InstantiateRoundLegs();
            } else if (legType == 1)
            {
                CreationControls creationControls = GameObject.Find("Room").GetComponent<CreationControls>();
                creationControls.InstantiateSquareLegs();
            }
        }

    }
}

