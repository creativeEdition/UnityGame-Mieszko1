using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonumentDestroy : MonoBehaviour {

    public GameObject monument;
    public GameObject cross;
	// Use this for initialization
	void Start () {
        monument = GameObject.FindGameObjectWithTag("pomnik");
        cross.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
        Check();
	}
    void Check()
    {
        if(monument == null)
        {
            cross.SetActive(true);
        }
    }
}
