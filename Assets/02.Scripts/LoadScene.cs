using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public void SceneLoad(string name) {
        if(name!=null) SceneManager.LoadScene(name);
        
    }

    public void QuitGame() {
        Application.Quit();
    }

}
