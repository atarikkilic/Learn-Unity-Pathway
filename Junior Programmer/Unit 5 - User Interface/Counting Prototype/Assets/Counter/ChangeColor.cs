using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material Material1;
    //in the editor this is what you would set as the object you wan't to change
    public GameObject Object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ColorChanger();
    }
    
    private void ColorChanger()
    {
        Object.GetComponent<MeshRenderer>().material = Material1;
    }
}
