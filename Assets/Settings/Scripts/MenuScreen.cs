using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuScreen : MonoBehaviour
{
   public void OnPlayButton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
