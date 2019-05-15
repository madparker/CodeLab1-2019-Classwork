using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPool : MonoBehaviour
{
    public List<GameObject> boxList; //declared boxList
    
    // Start is called before the first frame update
    void Start()
    {
        boxList = new List<GameObject>(); //init boxList
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetBox()
    {
        GameObject result = null;
        
        if (boxList.Count > 0) //Do we have any boxes to recycle?
        {
            //get a box out of the list and recycle it
            result = boxList[0];
            boxList.Remove(result);
            result.SetActive(true);
        }
        else  //No?
        {
            //make a new box
            result = Instantiate(Resources.Load<GameObject>("Prefabs/Box")); //init prefab from resources
        }

        return result;
    }
}
