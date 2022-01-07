using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegControls : MonoBehaviour
{
    public Vector3 tableScale; //make this private again
    private Vector3 tablePos;
    private float legOffset;
    private Vector3 legScale;
    public GameObject[] legs;
    public List<GameObject> legPrefabs;
    public List<Material> materialOptions;
    public bool isSelected;
    int legType = 0;
    private TabletopControls tabletopControls;
    
    // Start is called before the first frame update
    void Start()
    {
        //position issue won't be a problem once we get timing right; tabletop first, then legs
        tableScale = transform.localScale;
        tablePos = transform.position;
        tabletopControls = GetComponent<TabletopControls>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tableScale = transform.localScale;
        tablePos = transform.position;

        if (isSelected)
        {
            float moveSpeed = 0.05f;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            if (horizontalInput != 0 || verticalInput != 0)
            {
                Vector3 changeVector = new Vector3(horizontalInput * moveSpeed, 0, verticalInput * moveSpeed);
                foreach (GameObject leg in legs)
                {
                    leg.transform.position += changeVector;
                }
            }
        }
    }

    public void ShiftLegs(Vector3 shiftValues)
    {
        foreach(GameObject leg in legs)
        {
            leg.transform.position += shiftValues;
        }
    }


    public void UpdateLegPositions()
    {
        legScale = legs[0].transform.localScale;
        legOffset = legScale.x / 2;
        tableScale = transform.localScale;
        tablePos = transform.position;
        Debug.Log(tablePos);
        List<Vector3> legPositions = GetLegPositions();
        for (int i = 0; i < legs.Length; i++)
        {
            legs[i].transform.position = legPositions[i];
        }
    }

    private  List<Vector3> GetLegPositions()
    {
        List<Vector3> positions = new List<Vector3>();
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


}
