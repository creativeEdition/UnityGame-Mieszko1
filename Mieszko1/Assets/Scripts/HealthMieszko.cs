using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMieszko : MonoBehaviour {
    
    //creating array to store Mieszko lvl/hearts
    public Sprite[] heartsElements;
    //for access image hearts in UI
    public Image heartUI;
    //for access Mieszko health
    private MieszkoMovement mieszko;

	void Start () {
        mieszko = GameObject.FindGameObjectWithTag("Mieszko").GetComponent<MieszkoMovement>();
	}
    void  Update()
    { 
        heartUI.sprite =  heartsElements[(int)mieszko.actualHealth];
    }

}
