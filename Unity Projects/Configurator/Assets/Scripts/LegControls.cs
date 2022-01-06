using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegControls : MonoBehaviour
{
    private Vector3 tableScale;
    private Vector3 tablePos;
    private float legOffset;
    private Vector3 legScale;
    private float legDiameter;
    public List<GameObject> legs;
    // Start is called before the first frame update
    void Start()
    {
        tableScale = transform.localScale;
        tablePos = transform.position;
        legScale = legs[0].transform.localScale;
        legOffset = legs[0].transform.localScale.x / 2;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void updateLegPositions()
    {
        tableScale = transform.localScale;
        tablePos = transform.position;
        List<Vector3> legPositions = getLegPositions();
        for (int i = 0; i < legs.Count; i++)
        {
            legs[i].transform.position = legPositions[i];
        }
    }

    List<Vector3> getLegPositions()
    {
        Debug.Log(legOffset);
        List<Vector3> positions = new List<Vector3>();
        Vector3 brPos = new Vector3(((tablePos.x + tableScale.x / 2) - legOffset), (legScale.y/2), -((tablePos.z - tableScale.z / 2)) - legOffset);
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
