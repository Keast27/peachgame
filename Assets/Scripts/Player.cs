using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    // Start is called before the first frame update    
    //public GameObject[,] tiles;
    GameObject CurrentTile;
    GameObject StartingTile;

   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public virtual void MoveOne(Vector2 currLoc)
    {
       
    }

    public virtual void MoveTwo(Vector2 currLoc)
    {

    }

    public virtual void MoveThree(Vector2 currLoc)
    {

    }

    public void CallMove(int moveNum, Vector2 currLoc)
    {
        if(moveNum == 1)
        {
            MoveOne(currLoc);
        }
        if (moveNum == 2)
        {
            MoveTwo(currLoc);
        }
        if (moveNum == 3)
        {
            MoveThree(currLoc);
        }
    }

    public virtual void PreviewMove(int moveNum, Vector2 currLoc, GameObject[,] tiles)
    {
        if (moveNum == 1)
        {
        }
        if (moveNum == 2)
        {
            
        }
        if (moveNum == 3)
        {
            
        }
    }

    public bool CheckTile(int x, int y, GameObject[,] tiles)
    {

        if (x < tiles.GetLength(0) && y < tiles.GetLength(0) && !(x < 0) && !(y < 0))
        {
            return true;
        }
        return false;    
    }
}
