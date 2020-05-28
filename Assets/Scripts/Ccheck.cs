using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ccheck : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isColliding;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collide)
    {
        if(collide.tag == "Walk Tile")
        {
            Debug.Log(collide.ToString() + "We touchin fool");
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }
    
    void OnTriggerExit(Collider collide)
    {
        if (collide.tag == "Walk Tile")
        {
            Debug.Log("We not touchin fool");
            isColliding = false;
        }
    }
    
}
