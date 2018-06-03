using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GUIController: MonoBehaviour {

    public GameObject gameInterface;
    public GameObject pauseInterface;
    public GameObject dieInterface;
    public GameObject rubinInterface;
    public GameObject nextLevelInterface;  
    public Transform Mieszko;

    private void Start()
    {
        pauseInterface.SetActive(false);
        dieInterface.SetActive(false);
        nextLevelInterface.SetActive(false);
        rubinInterface.SetActive(true);      
    }
    public void PauseActivated()
    {
        FindObjectOfType<AudioManager>().PlaySounds("soundClick");
        pauseInterface.SetActive(true);
        gameInterface.SetActive(false);
        dieInterface.SetActive(false);
        rubinInterface.SetActive(true);
        nextLevelInterface.SetActive(false);

        Mieszko.GetComponent<MieszkoMovement>().enabled = false;
    }
    public void PlayContinue()
    {
        FindObjectOfType<AudioManager>().PlaySounds("soundClick");
        pauseInterface.SetActive(false);
        gameInterface.SetActive(true);
        dieInterface.SetActive(false);
        rubinInterface.SetActive(true);
        nextLevelInterface.SetActive(false);

        Mieszko.GetComponent<MieszkoMovement>().enabled = true;
    }
    public void DieEvent()
    {
        FindObjectOfType<AudioManager>().PlaySounds("soundClick");
        pauseInterface.SetActive(false);
        gameInterface.SetActive(false);
        dieInterface.SetActive(true);
        rubinInterface.SetActive(false);
        nextLevelInterface.SetActive(false);

        Mieszko.GetComponent<MieszkoMovement>().enabled = false;      
    }
    //this function is used when all mission complete in scene, allow to load new scene
    public void LevelComplete()
    {
        pauseInterface.SetActive(false);
        gameInterface.SetActive(false);
        dieInterface.SetActive(false);
        rubinInterface.SetActive(true);
        nextLevelInterface.SetActive(true);

        Mieszko.GetComponent<MieszkoMovement>().enabled = false;
    }

    public void LoadScene(string nameScene)
    {
        FindObjectOfType<AudioManager>().PlaySounds("soundClick");
        if(nameScene == "StartMenu")
        {
            Destroy(GameObject.Find("AudioManager"));
        }
        SceneManager.LoadScene(nameScene);
        Resources.UnloadUnusedAssets();
    }
    public void ExitGame()
    {
        FindObjectOfType<AudioManager>().PlaySounds("soundClick");
        Debug.Log("QUIT GAME!");
        Application.Quit();
    }
}
