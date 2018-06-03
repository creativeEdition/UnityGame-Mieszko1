using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    private ItemCount numberItem;

    void Start()
    {
        numberItem = GameObject.FindGameObjectWithTag("itemCount").GetComponent<ItemCount>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mieszko")
        {           
            numberItem.numberOfRubins += 1;
            Destroy(this.gameObject, 0.3f);
        }
    }
}
