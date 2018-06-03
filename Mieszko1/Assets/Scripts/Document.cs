using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document : MonoBehaviour {

    public bool isDocumentOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Mieszko")
        {
            isDocumentOpen = true;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
