using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void NewGameBtn (string GamePlay)
    {
        SceneManager.LoadScene(GamePlay);
    }

    public void QuitGameBtn()
    {
        Application.Quit();
    }
}
