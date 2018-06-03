using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontroller : MonoBehaviour {

    public GameObject germanEmperor;
    public GameObject hodo;
	// Use this for initialization
	void Start () {
        germanEmperor.SetActive(false);
	}
	void CheckIsExist()
    {
        if(hodo == null)
        {
            germanEmperor.SetActive(true);
        }
    }
	// Update is called once per frame
	void Update () {
        CheckIsExist();
	}
}
