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
}
