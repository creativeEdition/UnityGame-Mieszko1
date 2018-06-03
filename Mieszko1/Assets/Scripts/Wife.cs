using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wife : MonoBehaviour {

    private DialogueManager dm;
    private MieszkoMovement mieszkoMovement;
    public GameObject itemDrop;
    private bool gaveItem;
    private bool changePosition;
    private bool stopGive;
    private bool isThisWife;
    private int numberOfRevard = 0;
    private Vector3 wifeNewPosition;
    public Transform wife;
    //public Dialogue dialogue;
    // Use this for initialization
    void Start () {
        gaveItem = false;
        changePosition = false;
        wifeNewPosition.Set(50.2f, -43f, 0);
        dm = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        mieszkoMovement = FindObjectOfType<MieszkoMovement>().GetComponent<MieszkoMovement>();
       // numberItem = GameObject.FindGameObjectWithTag("itemCount").GetComponent<ItemCount>();
    }
	
    public void CheckConversation()
    {
        if ((dm.conversationEnd == true) && (numberOfRevard < 1)&&(mieszkoMovement.isThisWife == true))
        {         
            gaveItem = true;

            if (gaveItem == true) 
            {
                GiveRevard();
                changePosition = true;
            }            
        }
        else
        {
            gaveItem = false;
        }

    }
    void GiveRevard()
    {
        // numberOfRevard = numberItem.numberOfRubins += 1;
        numberOfRevard += 1;
            GameObject temporaryItem = Instantiate(itemDrop, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            temporaryItem.transform.position = this.transform.position;

    }
    void ChangePosiotion()
    {
        if(changePosition == true)
        {
            transform.position = wifeNewPosition;
            //thanks to this dialog system don't show up, circleCollider has trigger that activate dialog
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        
    }
    // Update is called once per frame
    void Update () {
        CheckConversation();
        ChangePosiotion();
    }
}
