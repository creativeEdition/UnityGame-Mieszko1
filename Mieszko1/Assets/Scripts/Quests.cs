using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //if I want to show in unity inspector to edit that script I have to add this
public class Quests
{
    //object of this class will be used wen we want to start new dialogue
    //contains information about single dialogue and 
    //we can pass into the DialogueManager

    //name of NPC
    public string nameTitle;
    [TextArea(1, 15)]
    //this string will hold dialog that we can load
    public string[] missions;


}