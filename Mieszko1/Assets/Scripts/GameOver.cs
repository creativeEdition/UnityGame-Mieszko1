using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    private Queue<string> narrations;
    public bool conversationEnd = false;
    public GameObject gameOverInterface;
    public Quests questContent;

    public Text nameText;
    public Text questText;

    // Use this for initialization
    void Start()
    {
        narrations = new Queue<string>();
        gameOverInterface.SetActive(false);
        NarrationActivated(questContent);
    }

    public void NarrationActivated(Quests quests)
    {
        nameText.text = quests.nameTitle;
        narrations.Clear();

        foreach (string narration in quests.missions)
        {
            narrations.Enqueue(narration);

        }

        PlayNextNarration();
    }

    public void PlayNextNarration()
    {
        if (narrations.Count == 0)
        {
            conversationEnd = true;
            Debug.Log("did conversation was full" + conversationEnd);
            return;
        }
        string sentence = narrations.Dequeue();
        //Debug.Log(sentence);
        questText.text = sentence;
    }
}
