using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mieszko")
        {
            FindObjectOfType<DialogueManager>().DialogueActivated(dialogue);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mieszko")
        {
            FindObjectOfType<DialogueManager>().DialogueDeactiv();
        }
    }
}
