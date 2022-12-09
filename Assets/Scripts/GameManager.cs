using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject goPanel;

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            goPanel.SetActive(true);
        }
    }
}
