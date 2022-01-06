using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneButtonControls : MonoBehaviour
{
    public GameObject activeObject;
    public Component script;
    public Material originalMaterial;
    private Material selectedItemMaterial;
    // Start is called before the first frame update

    public void setActiveObject(GameObject activeObj)
    {
        activeObject = activeObj;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
    }
}
