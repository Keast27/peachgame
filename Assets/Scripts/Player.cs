using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    // Start is called before the first frame update    
    public GameObject[,] tiles;
    public GameObject grid;
    GameObject CurrentTile;
    GameObject StartingTile;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiles = grid.GetComponent<GridSize>().tiles;
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

   

    public bool CheckTile(int x, int y)
    {
        return grid.GetComponent<GridSize>().CheckIndex(x, y);
    }
}
