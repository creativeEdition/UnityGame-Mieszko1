using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCount : MonoBehaviour {

    public int numberOfRubins;
    public Text textRubin;
    

	// Update is called once per frame
	void Update () {

        textRubin.text = (" " + numberOfRubins);
         if(numberOfRubins == 3)
        {
            FindObjectOfType<GUIController>().LevelComplete();
        }
    }

}
