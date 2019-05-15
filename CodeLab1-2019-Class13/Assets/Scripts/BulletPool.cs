using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public List<GameObject> bulletPool; //declared my list of GameObjects

    public static BulletPool instance; //make a static var to create a singleton
    
    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new List<GameObject>(); //init bulletPool

        //singleton pattern below
        if (instance == null) //check to see if instance is set
        {
            instance = this;    //if not, make this instance
            DontDestroyOnLoad(gameObject); //don't destroy this object
        }
        else
        {
            Destroy(gameObject); //destroy this because there's already a singleton
        }
    }

    public void AddBullet(GameObject bullet) //add a bullet to the pool
    {
        bulletPool.Add(bullet); //add bullet to the list
        bullet.SetActive(false); //turn it off
    }

    public GameObject GetBullet() //get a bullet from the pool or create it
    {
        GameObject result = null; //declare result
        
        if (bulletPool.Count > 0) //if there are bullets in the pool
        {
            result = bulletPool[0]; //get a bullet
            bulletPool.Remove(result); //remove it from the list
            result.SetActive(true); //turn it on
        }
        else //if there's no bullets in the pool
        {
            result = Instantiate(Resources.Load<GameObject>("Prefabs/Bullet")); //make a new bullet
        }

        return result; //return the result bullet
    }
}
