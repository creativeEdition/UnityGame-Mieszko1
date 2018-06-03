using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLast : MonoBehaviour {

    private ItemCountLastScene numberLastItem;

    void Start()
    {
        numberLastItem = GameObject.FindGameObjectWithTag("itemCount").GetComponent<ItemCountLastScene>();

    }
    // to save score 25
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mieszko")
        {
            numberLastItem.numberOfRubins += 1;
            Destroy(this.gameObject, 0.3f);
        }
    }
}
