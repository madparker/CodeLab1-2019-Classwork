using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemType : MonoBehaviour
{
    public Material[] materials; //array of materials

    public int type; //int  theat represents the type of gem
    
    // Start is called before the first frame update
    void Start()
    {
        type = Random.Range(0, materials.Length); //set the type to random number
        GetComponent<MeshRenderer>().material = materials[type]; //select the material that matches that random number in the materials array
    }

    // Update is called once per frame
    void Update()
    {
    }
}
