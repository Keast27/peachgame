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
    private GameObject[,] tiles;
    void Start()
    {
       tiles = new GameObject[rows, col];

        for(int i = 0; i < rows; i++)
        {
            float beginX = startX;

            for(int j = 0; j < col; j++)
            {
                GameObject newTile = Instantiate(tile, new Vector3(beginX, startY , startZ), Quaternion.identity);
                newTile.transform.Rotate(90 - theta, 0.0f, 0.0f, Space.Self);

        beginX += tile.GetComponent<SpriteRenderer>().bounds.size.x;
                tiles[i, j] = newTile;
            }
            startY -= tile.GetComponent<SpriteRenderer>().bounds.size.z/2 * (Mathf.Sin(theta * Mathf.Deg2Rad))  ;
            startZ -= tile.GetComponent<SpriteRenderer>().bounds.size.z/2 * (Mathf.Cos(theta * Mathf.Deg2Rad));
            beginX = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void ResetGrid()
    {
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < col; j++)
            {
                tiles[i, j].tag = "Untagged";
            }
        }
    }

    private Vector2 FindIndex(GameObject currentTile)
    {
      
        Vector2 index = new Vector2(0, 0);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if(tiles[i, j] = currentTile)
                {
                    index = new Vector2(i, j);
                }
            }
        }   
        return index;
    }

}
