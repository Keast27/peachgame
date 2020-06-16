using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeachMoves : Player
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void MoveOne(Vector2 currLoc)
    {       
        Debug.Log("It works!");

        tiles[(int)currLoc.x, (int) currLoc.y + 1].GetComponent<SpriteRenderer>().color = Color.black;
        
        
    }

}
