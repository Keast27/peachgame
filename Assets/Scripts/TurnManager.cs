using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public enum CurrentTurn
    {
        Hero,
        Enem,
        Boss,
    }
   
    public List<GameObject> TurnOrder = new List<GameObject>();
    int turn = 0;
    int move = 0;
    private GameObject currentChara;
    
    //Public for debugging
    public CurrentTurn currentTurn;

    private PeachMoves peach = new PeachMoves();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(TurnOrder.Count);
        currentChara = TurnOrder[0];
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentTurn) {
            case CurrentTurn.Hero:
                if (Input.GetKey(KeyCode.I))
                {
                    //Check tag to see if it is hero
                    move = 1;
                }
                if (Input.GetKey(KeyCode.O))
                {
                    move = 2;
                }
                if (Input.GetKey(KeyCode.P))
                {
                    move = 3;
                }
                if (Input.GetKey(KeyCode.Space) && move!=0)
                {
                   GetMove(currentChara);
                    SetTurn();
                }
                break;
            case CurrentTurn.Enem:
                if (Input.GetKey(KeyCode.Tab))
                {

                }
                break;
            case CurrentTurn.Boss:
                break;
        }

    }

    private void SetTurn()
    {
        //Turn tracker
        turn++;
        if(turn+1 >= TurnOrder.Count)
        {
            turn = 0;
        }

        if(TurnOrder[turn].tag == "Player")
        {
            currentTurn = CurrentTurn.Hero;
        }

        if (TurnOrder[turn].tag == "Enemy")
        {
            currentTurn = CurrentTurn.Enem;
        }
        if (TurnOrder[turn].tag == "Boss")
        {
            currentTurn = CurrentTurn.Boss;
        }
    }

    private void GetMove(GameObject currentPlayer)
    {
       if(currentPlayer.name == "Peach")
        {
            peach.CallMove(move);
        }
        if (currentPlayer.name == "Mario?")
        {

        }
        if (currentPlayer.name == "Luigi??")
        {

        }
        if (currentPlayer.name == "Bowser?????")
        {

        }
    }
    private void OnGUI()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "This is a box");
        }
      
    }
}
