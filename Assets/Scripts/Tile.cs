using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool walkable;
    public bool isEnemy;
    public List<Tile> neighbors = new List<Tile>();
    protected Tile up;
    protected Tile down;
    protected Tile left;
    protected Tile right;
    public bool ActiveTile = false;
    private bool alreadyActive = false;
    public bool isPreview;
    public bool isAttack;


    public Sprite[] sprites;




    public int priority;

    private GameObject tile;

    public Tile Up
    {
        get { return up; }
        set { this.up = value; }
    }
    public Tile Down
    {
        get { return down; }
        set { this.down = value; }
    }
    public Tile Left
    {
        get { return left; }
        set { this.left = value; }
    }
    public Tile Right
    {
        get { return right; }
        set { this.right = value; }
    }

    public Tile()
    {
        walkable = false;
        isEnemy = false;
        up = null;
        down = null;
        left = null;
        right = null;
    }

    public void PrintConnections()
    {
        Debug.Log("Top: " + up.walkable + " Bottom: " + down.walkable + " Right: " + right.walkable + " Left: " + left.walkable);
    }

    //Start tile.FillGraphR
    public void FillGraphR(int speed)
    {
        if (speed != 0)
        {
            walkable = true;

            if (left != null && left.isEnemy != true)
            {
                left.FillGraphR(speed - 1);
            }
            if (up != null && up.isEnemy != true)
            {
                up.FillGraphR(speed - 1);
            }
            if (down != null && down.isEnemy != true)
            {
                down.FillGraphR(speed - 1);
            }
            if (right != null && right.isEnemy != true)
            {
                right.FillGraphR(speed - 1);
            }

        }
    }

   

    private void OnTriggerEnter(Collider other)
    {
        UpdateTiles();
        if (other.tag == "Collide")
        {
            priority++;
        }
      
    }

   

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Collide")
        {
            priority--;
        }
    }


    private void UpdateTiles()
    {
        //make this better
        if (walkable == true)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }


        if (walkable == true && priority == 5)
        {
            ActiveTile = true;
            GetComponent<SpriteRenderer>().color = Color.magenta;
        }
        else if ((walkable == true || walkable == false) && priority != 5)
        {
            ActiveTile = false;
            if (isPreview == true)
            {
                GetComponent<SpriteRenderer>().sprite = sprites[1];
                GetComponent<SpriteRenderer>().color = Color.black;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }

        }
    }


    public void Start()
    {
        UpdateTiles();

    }

    public void Update()
    {

      /*  
        if((alreadyActive == false) && (ActiveTile == true))
        {
            UpdateTiles();

        }

        alreadyActive = ActiveTile;
        */
        UpdateTiles();
    }
}
