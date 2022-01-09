using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreationControls : MonoBehaviour
{
    public Button rectTableButton;
    public Button squareTableButton;
    public Button squareLegsButton;
    public Button roundLegsButton;
    public GameObject rectTablePrefab;
    public GameObject squareTablePrefab;
    public GameObject squareLegPrefab;
    public GameObject roundLegPrefab;
    public GameObject createTools;
    public GameObject editTools;
    private LegControls legControls;
    private Vector3 tablePos;
    private Vector3 tableScale;
    public Button newSceneButton;


    // Add listeners to buttons in create panel
    void Start()
    {
        tablePos = new Vector3(0, 1.05f, 0);
        rectTableButton.GetComponent<Button>().onClick.AddListener(InstantiateRectangle);
        squareTableButton.GetComponent<Button>().onClick.AddListener(InstantiateSquare);
        squareLegsButton.GetComponent<Button>().onClick.AddListener(InstantiateSquareLegs);
        //roundLegsButton.GetComponent<Button>().onClick.AddListener(InstantiateRoundLegs);
        newSceneButton.GetComponent<Button>().onClick.AddListener(ReloadScene);
    }

    void ReloadScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    //Instantiate rectangle tabletop and activate leg option buttons
    void InstantiateRectangle()
    {
        Instantiate(rectTablePrefab, tablePos, rectTablePrefab.transform.rotation);
        tableScale = GameObject.FindGameObjectWithTag("tabletop").transform.localScale;
        ActivateLegButtons();
    }

    //Instantiate square tabletop and activate leg option buttons
    void InstantiateSquare()
    {
        Instantiate(squareTablePrefab, tablePos, squareTablePrefab.transform.rotation);
        tableScale = GameObject.FindGameObjectWithTag("tabletop").transform.localScale;
        ActivateLegButtons();
        
    }

    //Actives leg buttons and defines leg controls
    void ActivateLegButtons()
    {
        squareLegsButton.gameObject.SetActive(true);
        roundLegsButton.gameObject.SetActive(true);
        legControls = GameObject.FindGameObjectWithTag("tabletop").GetComponent<LegControls>();
    }

    //Instantiates square legs under tabletop
    void InstantiateSquareLegs()
    { 
        List<Vector3> positions = GetLegPositions(squareLegPrefab.transform.localScale.x/2, squareLegPrefab.transform.localScale);

        for (int i = 0; i < 4; i++)
        {
            Instantiate(squareLegPrefab, positions[i], squareLegPrefab.transform.rotation);

        }
        TabletopControls tabletopControls = GameObject.FindGameObjectWithTag("tabletop").GetComponent<TabletopControls>();
        GameObject.FindGameObjectWithTag("tabletop").GetComponent<LegControls>().legs = GameObject.FindGameObjectsWithTag("leg");
        tabletopControls.hasLegs = true;
        ActivateEditPanel();

    }

    //Doesn't work yet; no round leg prefab
    /*void InstantiateRoundLegs()
    {
        List<Vector3> positions = GetLegPositions(squareLegPrefab.transform.localScale.x / 2, squareLegPrefab.transform.localScale);

        for (int i = 0; i < 4; i++)
        {
            Instantiate(roundLegPrefab, positions[i], roundLegPrefab.transform.rotation);

        }

    }*/


    //Generates leg positions
    public List<Vector3> GetLegPositions(float legOffset, Vector3 legScale)
    {
        List<Vector3> positions = new List<Vector3>();
        Debug.Log(tableScale);
        Vector3 brPos = new Vector3(((tablePos.x + tableScale.x / 2) - legOffset), (legScale.y / 2), -((tablePos.z - tableScale.z / 2)) - legOffset);
        positions.Add(brPos);
        Vector3 frPos = new Vector3(((tablePos.x + tableScale.x / 2) - legOffset), (legScale.y / 2), ((tablePos.z - tableScale.z / 2)) + legOffset);
        positions.Add(frPos);
        Vector3 blPos = new Vector3(((tablePos.x - tableScale.x / 2) + legOffset), (legScale.y / 2), -((tablePos.z - tableScale.z / 2)) - legOffset);
        positions.Add(blPos);
        Vector3 flPos = new Vector3(((tablePos.x - tableScale.x / 2) + legOffset), (legScale.y / 2), ((tablePos.z - tableScale.z / 2)) + legOffset);
        positions.Add(flPos);
        return positions;
    }

    //Switch panel from create mode to edit mode
    void ActivateEditPanel()
    {
        createTools.SetActive(false);
        editTools.SetActive(true);
    }

    void switchToWood()
    {

    }

    void switchToPlastic()
    {

    }
}

