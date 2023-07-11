using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainAndQuit : MonoBehaviour
{
   
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void Quite()
    {
        Application.Quit();
    }

}
