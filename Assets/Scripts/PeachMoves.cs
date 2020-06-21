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

        
        
    }
    public override void PreviewMove(int moveNum, Vector2 currLoc, GameObject[,] tiles)
    {
        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                tiles[i, j].GetComponent<Tile>().isPreview = false;
            }
        }
        if (moveNum == 1)
        {
            if (CheckTile((int)currLoc.x, (int)currLoc.y, tiles))
            {
                tiles[(int)currLoc.x, (int)currLoc.y + 1].GetComponent<Tile>().isPreview = true;
                if (CheckTile((int)currLoc.x + 1, (int)currLoc.y + 1, tiles))
                {
                    tiles[(int)currLoc.x + 1, (int)currLoc.y + 1].GetComponent<Tile>().isPreview = true;
                }
                if (CheckTile((int)currLoc.x - 1, (int)currLoc.y + 1, tiles))
                {
                    tiles[(int)currLoc.x - 1, (int)currLoc.y + 1].GetComponent<Tile>().isPreview = true;
                }
            }
            //theory: x and y are switched
        }
        else if (moveNum == 2)
        {
            if (CheckTile((int)currLoc.x, (int)currLoc.y, tiles))
            {
                tiles[(int)currLoc.x, (int)currLoc.y + 1].GetComponent<Tile>().isPreview = true;
            }
        }
    }
}
