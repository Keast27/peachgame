using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSize : MonoBehaviour
{
    // Start is called before the first frame update
    public int rows;
    public int col;
    public float startX;
    public float startY;
    public float startZ;
    public float theta;
    public GameObject tile;
    public GameObject Moving;
    public List<GameObject> walkTiles = new List<GameObject>();
    public GameObject[,] tiles;


    
   //Variables from Graph test
    public int startXTile;
    public int startYTile;
    private int currX;
    private int currY;
    private int speed;
    public Tile start;
    public Sprite[] sprites;

    public Vector2 standingTilePos;

    public GameObject standing;
        
    void Start()
    {
       // sprites = Resources.LoadAll<Sprite>(spriteNames);
        tiles = new GameObject[rows, col];
       
        for (int i = 0; i < rows; i++)
        {
            float beginX = startX;

            for(int j = 0; j < col; j++)
            {
                GameObject newTile = Instantiate(tile, new Vector3(beginX, startY , startZ), Quaternion.identity);
                newTile.transform.Rotate(90 - theta, 0.0f, 0.0f, Space.Self);

                beginX += tile.GetComponent<SpriteRenderer>().bounds.size.x;
                newTile.GetComponent<Tile>().walkable = false;               
                tiles[i, j] = newTile;
            }
            startY -= tile.GetComponent<SpriteRenderer>().bounds.size.z * (Mathf.Sin(theta * Mathf.Deg2Rad));
            startZ -= tile.GetComponent<SpriteRenderer>().bounds.size.z * (Mathf.Cos(theta * Mathf.Deg2Rad));
            beginX = 0;
        }

       
        SetNeighbors(rows, col);
        SetStartLocnSpd(startXTile, startYTile, 4);
        FillGraph();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject t in tiles)
        {
           if(t.GetComponent<Tile>().ActiveTile == true)
            {
                standing = t;
            }            
        }
       
    }   

    private void ResetGrid()
    {
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < col; j++)
            {
                tiles[i, j].tag = "Untagged";
                tiles[i, j].GetComponent<Tile>().walkable = false;

            }
        }

        if(walkTiles.Count != 0)
        {
            walkTiles.Clear();
        }
    }

    //Assigns neighbors in grid
    private void SetNeighbors(int rows, int col)
    {
        //  tiles = new Tile[rows, col];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Tile currentTile = tiles[i, j].GetComponent<Tile>();
                //If there's a tile above
                if (CheckIndex(i, j + 1))
                {

                    currentTile.GetComponent<Tile>().Up = tiles[i, j + 1].GetComponent<Tile>();
                }
                //If there's a tile below
                if (CheckIndex(i, j - 1))
                {
                    currentTile.Down = tiles[i, j - 1].GetComponent<Tile>();
                }
                //If there's a tile left
                if (CheckIndex(i - 1, j))
                {
                    currentTile.Left = tiles[i - 1, j].GetComponent<Tile>();
                }
                //If there's a tile right
                if (CheckIndex(i + 1, j))
                {
                    currentTile.Right = tiles[i + 1, j].GetComponent<Tile>();
                }
               // tiles[i, j].GetComponent<Tile>() = currentTile;

            }
        }

    }

    public void SetStartLocnSpd(int x, int y, int spd)
    {
        startXTile= x;
        startYTile = y;
        speed = spd;
        start = tiles[startXTile, startYTile].GetComponent<Tile>();
        start.tag = "Walk Tile";
        start.GetComponent<Tile>().walkable = true;
        start.GetComponent<SpriteRenderer>().sprite = sprites[1];
        currX = startXTile;
        currY = startYTile;
    }

    //Not implemented yet
    public void PlaceEnemy(int x, int y)
    {
        tiles[x, y].GetComponent<Tile>().walkable = false;
        tiles[x, y].GetComponent<Tile>().isEnemy = true;

    }

    private void Recenter()
    {
        currX = startXTile;
        currY = startYTile;
    }

    //Checks if index is valid
    public bool CheckIndex(int x, int y)
    {
        if (x < tiles.GetLength(0) && y < tiles.GetLength(0) && !(x < 0) && !(y < 0))
        {
            return true;
        }
        return false;
    }


    public void FillGraph()
    {

        int currentSpeed = speed;
        int searchStep = 4;
        int tempSearch = speed;


        while (searchStep != 0)
        {
            #region West
            //If it's in index and unchecked
            if (CheckIndex(currX, currY - 1) && (tiles[currX, currY - 1].GetComponent<Tile>().walkable == false))
            {

                for (int k = 0; k < currentSpeed - 1; k++)
                {
                    tempSearch--;
                    currY -= 1;

                    for (int i = 0; i < tempSearch; i++)
                    {

                        if (CheckIndex(currX + i, currY))
                        {
                            if (tiles[currX + i, currY].GetComponent<Tile>().isEnemy == false)
                            {
                              SetTileWalk(tiles[currX + i, currY]);
                            }
                        }


                    }

                    for (int i = 0; i < tempSearch; i++)
                    {
                        if (CheckIndex(currX - i, currY))
                        {

                            if (tiles[currX - i, currY].GetComponent<Tile>().isEnemy == false)
                            {
                                SetTileWalk(tiles[currX - i, currY]);
                            }

                        }

                    }
                }

            }
            #endregion
            Recenter();
            tempSearch = speed;
            #region East
            //If it's in index and unchecked
            if (CheckIndex(currX, currY + 1) && (tiles[currX, currY + 1].GetComponent<Tile>().walkable == false))
            {

                for (int k = 0; k < currentSpeed - 1; k++)
                {
                    tempSearch--;
                    currY += 1;
                    for (int i = 0; i < tempSearch; i++)
                    {

                        if (CheckIndex(currX + i, currY))
                        {
                            if (tiles[currX + i, currY].GetComponent<Tile>().isEnemy == false)
                            {
                                SetTileWalk(tiles[currX + i, currY]);
                            }
                        }
                    }

                    for (int i = 0; i < tempSearch; i++)
                    {
                        if (CheckIndex(currX - i, currY))
                        {
                            if (tiles[currX - i, currY].GetComponent<Tile>().isEnemy == false)
                            {
                              SetTileWalk(tiles[currX - i, currY]);
                            }
                        }

                    }
                }

            }
            #endregion
            Recenter();
            tempSearch = speed;
            #region North
            //If it's in index and unchecked
            if (CheckIndex(currX - 1, currY) && (tiles[currX - 1, currY].GetComponent<Tile>().walkable == false))
            {

                for (int k = 0; k < currentSpeed - 1; k++)
                {
                    tempSearch--;
                    currX -= 1;
                    for (int i = 0; i < tempSearch; i++)
                    {
                        if (CheckIndex(currX, currY + i))
                        {
                            if (tiles[currX, currY + i].GetComponent<Tile>().isEnemy == false)
                            {
                               SetTileWalk(tiles[currX, currY + i]);
                            }
                        }
                    }

                    for (int i = 0; i < tempSearch; i++)
                    {
                        if (CheckIndex(currX, currY - i))
                        {
                            if (tiles[currX, currY - i].GetComponent<Tile>().isEnemy == false)
                            {
                                SetTileWalk(tiles[currX, currY - i]);
                            }
                        }

                    }
                }

            }
            #endregion

            Recenter();
            tempSearch = speed;
            #region South
            //If it's in index and unchecked
            if (CheckIndex(currX + 1, currY) && (tiles[currX + 1, currY].GetComponent<Tile>().walkable == false))
            {

                for (int k = 0; k < currentSpeed - 1; k++)
                {
                    tempSearch--;
                    currX += 1;
                    for (int i = 0; i < tempSearch; i++)
                    {
                        if (CheckIndex(currX, currY + i))
                        {
                            if (tiles[currX, currY + i].GetComponent<Tile>().isEnemy == false)
                            {
                                SetTileWalk(tiles[currX, currY + i]);
                            }
                        }
                    }

                    for (int i = 0; i < tempSearch; i++)
                    {
                        if (CheckIndex(currX, currY - i))
                        {
                            if (tiles[currX, currY - i].GetComponent<Tile>().isEnemy == false)
                            {
                                SetTileWalk(tiles[currX, currY - i]);                               
                            }

                        }

                    }
                }

            }
            #endregion

            searchStep = 0;
            // for(int i < )
            //Subtract at end of step
            // reset tempsearch
        }
    }


    //Helper method that sets the walkable tile's properties
    public void SetTileWalk(GameObject tile)
    {
        tile.tag = "Walk Tile";
        tile.GetComponent<Tile>().walkable = true;
        walkTiles.Add(tile);
        tile.GetComponent<SpriteRenderer>().sprite = sprites[1];
    }

    private void standingIndex()
    {
        for(int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if(standing == tiles[i, j])
                {
                    standingTilePos = new Vector2(i, j);
                }
            }
        }
    }
}

 