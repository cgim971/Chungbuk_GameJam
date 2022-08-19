using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    

    private void OnApplicationPause(bool pause) {
        PauseGame();
    }

    public void PauseGame() {
        canvas.enabled = true;
        Time.timeScale = 0f;
    }
    public void UnpauseGame() {
        canvas.enabled = false;
        Time.timeScale = 1f;
    }

}
