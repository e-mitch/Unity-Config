using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareTabletopDimensionsControls : MonoBehaviour
{
    private TabletopControls tabletopControls;
    // Start is called before the first frame update
    void Start()
    {
        tabletopControls = GetComponent<TabletopControls>();
        tabletopControls.dimensionPairs = CreateSquareDimensionPairs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<List<float>> CreateSquareDimensionPairs()
    {
        List<List<float>> pairs = new List<List<float>>();
        pairs.Add(new List<float> { 1f, 1f });
        pairs.Add(new List<float> { 1.5f, 1.5f });
        pairs.Add(new List<float> { 1.75f, 1.75f });

        return pairs;
    }
}
