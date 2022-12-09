using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    //restart game
    public void restartGame()
    {
        SceneManager.LoadScene("Level01");
    }

}
