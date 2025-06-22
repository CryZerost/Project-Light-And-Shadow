using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddFinish : MonoBehaviour
{
    public PlayerMovement player1;
    public PlayerMovement player2;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (player1 != null && other.gameObject == player1.gameObject && !player1.isFinish)
        {
            player1.isFinish = true;
            player1.gameObject.SetActive(false);
            Debug.Log("Player 1 Finish");
        }

        if (player2 != null && other.gameObject == player2.gameObject && !player2.isFinish)
        {

            player2.isFinish = true;
            player2.gameObject.SetActive(false);
            Debug.Log("Player 2 Finish");
        }
    }

    public void Update()
    {
        if (player1.isFinish && player2.isFinish)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
