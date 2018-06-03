using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    private Queue<string> sentences;
    public GameObject dialogueInterface;
    public bool conversationEnd = false;

    public Text nameText;
    public Text dialogueText;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
        dialogueInterface.SetActive(false);
	}

    public void DialogueActivated(Dialogue dialogue)
    {
        dialogueInterface.SetActive(true);
       // Debug.Log("Starting conversation with " + dialogue.nameNPC);

        nameText.text = dialogue.nameNPC;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        PlayNextSentence();
    }

    public void PlayNextSentence()
    {
        FindObjectOfType<AudioManager>().PlaySounds("soundClick");
        if (sentences.Count == 0)
        {
            conversationEnd = true;
            Debug.Log("did conversation was full" + conversationEnd);
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;
    }
    public void EndDialogue()
    {
 
        Debug.Log("End conversation! ");
        dialogueInterface.SetActive(false);
        
    }
    public void DialogueDeactiv()
    {
        Debug.Log("Stopped conversation! ");
        dialogueInterface.SetActive(false);
        conversationEnd = false;
    }
}
