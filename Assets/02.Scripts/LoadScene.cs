using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public void SceneLoad(int number)
    {
        SceneManager.LoadScene(number);
    }

    public void SceneLoad(string str)
    {
        SceneManager.LoadScene(str);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
