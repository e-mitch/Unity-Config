using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTabletopDimensionsControls : MonoBehaviour
{

    private TabletopControls tabletopControls;

    // Start is called before the first frame update
    void Start()
    {
        tabletopControls = GetComponent<TabletopControls>();
        tabletopControls.dimensionPairs = CreateRectDimensionPairs();
    }

    //Generates possible dimension pairs for tabletop
    private List<List<float>> CreateRectDimensionPairs()
    {
        List<List<float>> pairs = new List<List<float>>();
        pairs.Add(new List<float> { 2, 1 });
        pairs.Add(new List<float> { 2, 1.2f });
        pairs.Add(new List<float> { 2.2f, 1.2f });

        return pairs;
    }
}
