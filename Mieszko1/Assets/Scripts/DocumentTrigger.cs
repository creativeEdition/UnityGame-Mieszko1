using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentTrigger : MonoBehaviour {

    //public GameObject documentInterface;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mieszko")
        {  
            FindObjectOfType<DocumentManager>().CheckPlay();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mieszko")
        {
            FindObjectOfType<DocumentManager>().DocumentDeactiv();
        }
    }
}
