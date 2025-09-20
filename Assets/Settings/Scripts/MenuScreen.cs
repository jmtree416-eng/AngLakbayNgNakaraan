using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuScreen : MonoBehaviour
{
   public void OnPlayButton()
    {
        SceneManager.LoadSceneAysnc(1);
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
