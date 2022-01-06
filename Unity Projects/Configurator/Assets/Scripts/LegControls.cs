using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegControls : MonoBehaviour
{
    private Vector3 tableScale;
    private Vector3 tablePos;
    private float legOffset;
    private Vector3 legScale;
    public List<GameObject> legs;
    public bool selected;
    public List<Material> materialOptions;
    
    // Start is called before the first frame update
    void Start()
    {
        tableScale = transform.localScale;
        tablePos = transform.position;
        legScale = legs[0].transform.localScale;
        legOffset = legs[0].transform.localScale.x / 2;

    }

    // Update is called once per frame
    void LateUpdate()
    { 
        if (selected)
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
        tableScale = transform.localScale;
        tablePos = transform.position;
        List<Vector3> legPositions = GetLegPositions();
        for (int i = 0; i < legs.Count; i++)
        {
            legs[i].transform.position = legPositions[i];
        }
    }

    List<Vector3> GetLegPositions()
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
