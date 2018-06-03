using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void LoadScene(string sceneName)
    {
        FindObjectOfType<AudioManager>().PlaySounds("soundClick");
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        FindObjectOfType<AudioManager>().PlaySounds("soundClick");
        Debug.Log("QUIT GAME!");
        Application.Quit();
    }
}
