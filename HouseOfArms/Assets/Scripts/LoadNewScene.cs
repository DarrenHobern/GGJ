using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    public GameObject ThisUI;
    public GameObject OtherUI;

    public void LoadByIndex(int Sceneindex)
    {
        SceneManager.LoadScene(Sceneindex);
    }

    public void OpenOtherUI()
    {
        if(!ThisUI || !OtherUI)
        {
            Debug.Log("Can't find ThisUI or OtherUI, must initialise");
            return;
        }
        ThisUI.SetActive(false);
        OtherUI.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
