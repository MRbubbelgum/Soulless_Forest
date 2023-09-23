using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneControler : MonoBehaviour
{
    public void StartGame()
    {
        Invoke("LodadMenu", 2.0f);
    }

    public void QuitGame()
    {
        Invoke("LoadQuit", 2.0f);
    }

    private void LodadMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadQuit()
    {
        Application.Quit();
    }
}
