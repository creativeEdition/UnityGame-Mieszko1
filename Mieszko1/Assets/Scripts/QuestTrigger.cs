using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {
    public Quests quests;
    

    public void ShowQuestList()
    {
        FindObjectOfType<AudioManager>().PlaySounds("soundClick");
        FindObjectOfType<QuestManager>().QuestsActivated(quests);
    }
}
