using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monument : MonoBehaviour {

    public GameObject itemDrop;

    public float monumentHealth = 2f;


	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        HealthStatue();
	}
    public void DamageMonument(float injury)
    {
        monumentHealth -= injury * Time.deltaTime;
        gameObject.GetComponent<Animation>().Play("monumentDamage");
    }
    void HealthStatue()
    {
        if(monumentHealth <= 0)
        {
            GameObject temporaryItem = Instantiate(itemDrop, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            temporaryItem.transform.position = this.transform.position;
            DestroyStatue();
        }
    }
    void DestroyStatue()
    {
        Destroy(this.gameObject);
    }
}
