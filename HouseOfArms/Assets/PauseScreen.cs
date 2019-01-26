using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public void LoadScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void Continue()
    {
        GameControlScript.instance.TogglePauseMenu();
    }

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
