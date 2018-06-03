using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DocumentManager : MonoBehaviour {

    private Queue<string> pages;
    public GameObject documentInterface;
    public GameObject documentObject;
    public GameObject questInterface;
    public bool conversationEnd = false;

    public Text nameText;
    public Text questText;
    public Quests quests;

    // Use this for initialization
    void Start()
    {
        pages = new Queue<string>();
        documentInterface.SetActive(false);
        documentObject.GetComponent<Animation>().Play();
    }
    public void CheckPlay()
    {

            DocumentActivated(quests);
            documentInterface.SetActive(true);
            questInterface.SetActive(false);

    }
    public void DocumentActivated(Quests quests)
    {
        Debug.Log("Starting conversation with " + quests.nameTitle);

        nameText.text = quests.nameTitle;
        pages.Clear();
        documentObject.GetComponent<Animation>().Stop();

        foreach (string page in quests.missions)
        {
            pages.Enqueue(page);
        }

        PlayNextDocument();
    }

    public void PlayNextDocument()
    {
        FindObjectOfType<AudioManager>().PlaySounds("soundClick");
        if (pages.Count == 0)
        {
            conversationEnd = true;
            Debug.Log("did conversation was finish to end? " + conversationEnd);
            ExitShowDocument();           
            return;
        }
        string sentence = pages.Dequeue();
        //Debug.Log(sentence);
        questText.text = sentence;
    }
    public void ExitShowDocument()
    {
        FindObjectOfType<AudioManager>().PlaySounds("soundClick");
        Debug.Log("End of conversation! ");
        documentInterface.SetActive(false);
        questInterface.SetActive(true);
        Destroy(documentObject);
    }
    public void DocumentDeactiv()
    {
        Debug.Log("Stopped conversation! ");
        documentInterface.SetActive(false);
        questInterface.SetActive(true);
        conversationEnd = false;
        documentObject.GetComponent<Animation>().Play();
    }
}
