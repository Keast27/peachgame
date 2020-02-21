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
    public GameObject tile;

    GameObject[,] tiles;
    void Start()
    {
       tiles = new GameObject[rows, col];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
