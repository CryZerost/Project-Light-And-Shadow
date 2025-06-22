using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] bool isPlayerSwitch;

    public PlayerMovement player1;
    public PlayerMovement player2;

    void Start()
    {
        
    }

    public void playerMove()
    {
        if (isPlayerSwitch)
        {
            player1.isPlayerOn = true;
            player2.isPlayerOn = false;
        }
        else
        {
            player2.isPlayerOn = true;
            player1.isPlayerOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
        playerSwitch();

    }

    public void playerSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isPlayerSwitch)
        {
            isPlayerSwitch = false;

        }
        else if (Input.GetKeyDown(KeyCode.Q) && !isPlayerSwitch)
        {

            isPlayerSwitch = true;
        }
    }
}
