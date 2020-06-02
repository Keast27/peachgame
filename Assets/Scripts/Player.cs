using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    // Start is called before the first frame update
    public List<GameObject> walkTiles = new List<GameObject>();
    public GameObject grid;
    Tile CurrentTile;
    Tile StartingTile;

    void Start()
    {
        walkTiles = grid.GetComponent<GridSize>().walkTiles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void MoveOne()
    {
       
    }

    public virtual void MoveTwo()
    {

    }

    public virtual void MoveThree()
    {

    }

    public void CallMove(int moveNum)
    {
        if(moveNum == 1)
        {
            MoveOne();
        }
        if (moveNum == 2)
        {
            MoveOne();
        }
        if (moveNum == 3)
        {
            MoveOne();
        }
    }

    public void GetStandingTile()
    {
       
    }

    public bool CheckTile(int x, int y)
    {
        return grid.GetComponent<GridSize>().CheckIndex(x, y);
    }
}
