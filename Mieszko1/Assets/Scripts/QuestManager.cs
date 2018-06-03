using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

    private Queue<string> missions;
    public GameObject questInterface;
    public GameObject buttonQuest;
    public bool conversationEnd = false;

    public Text nameText;
    public Text questText;

    // Use this for initialization
    void Start()
    {
        missions = new Queue<string>();
        questInterface.SetActive(false);
        buttonQuest.GetComponent<Animation>().Play();
    }

    public void QuestsActivated(Quests quests)
    {
        Debug.Log("Starting conversation with " + quests.nameTitle);

        questInterface.SetActive(true);
        nameText.text = quests.nameTitle;
        missions.Clear();
        buttonQuest.GetComponent<Animation>().Stop();

        foreach (string mission in quests.missions)
        {
            missions.Enqueue(mission);
        }

        PlayNextQuests();
    }

    public void PlayNextQuests()
    {
        FindObjectOfType<AudioManager>().PlaySounds("soundClick");
        if (missions.Count == 0)
        {
            conversationEnd = true;
            Debug.Log("did conversation was finish to end? " + conversationEnd);
            ExitShowQuest();
            return;
        }
        string sentence = missions.Dequeue();
        //Debug.Log(sentence);
        questText.text = sentence;
    }
    public void ExitShowQuest()
    {
        FindObjectOfType<AudioManager>().PlaySounds("soundClick");
        Debug.Log("End of conversation! ");
        questInterface.SetActive(false);
    }

}
