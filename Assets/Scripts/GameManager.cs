using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public GameObject gameOverUi;



    private void Start()
    {
        gameIsOver = false;
    }
    void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverUi.SetActive(true);
    }

}
