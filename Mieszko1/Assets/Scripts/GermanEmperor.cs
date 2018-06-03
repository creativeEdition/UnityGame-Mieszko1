using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GermanEmperor : MonoBehaviour {

    private DialogueManager dm;
    private ItemCount numberOfitem;
    private bool hasGive = false;
    bool isThisMieszko = false;


    // Use this for initialization
    void Start () {
        dm = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        numberOfitem = GameObject.FindGameObjectWithTag("itemCount").GetComponent<ItemCount>();
	}

    // Update is called once per frame
    void Update()
    {
        GiveItem();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mieszko")
        {
            isThisMieszko = true;
        }
    }
    void GiveItem()
    {

        if (isThisMieszko == true)
        {
            Debug.Log("is this nptTalk: " + isThisMieszko);
            {
                if ((dm.conversationEnd == true) && (hasGive == false))
                {
                    numberOfitem.numberOfRubins += 1;
                    hasGive = true;
                }
            }
        }
           

        

    }
}
