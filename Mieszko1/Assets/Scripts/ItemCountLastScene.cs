using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCountLastScene : MonoBehaviour {

    public int numberOfRubins;
    public Text textRubin;
    public GameObject pauseButton;
    public GameObject questButton;
    public GameObject document;


    // Update is called once per frame
    void Update()
    {

        textRubin.text = (" " + numberOfRubins);
        if ((numberOfRubins == 4)&&(document == null))
        {
            FindObjectOfType<GameOver>().gameOverInterface.SetActive(true);
            pauseButton.SetActive(false);
            questButton.SetActive(false);
            FindObjectOfType<MieszkoMovement>().enabled = false;
        }

    }
}
