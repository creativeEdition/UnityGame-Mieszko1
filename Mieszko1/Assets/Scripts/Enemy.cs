using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Animator enemy;
    public MieszkoMovement mieszko;
    public GameObject itemDrop;

    float actualEnemyHealth;
    float maxEnemyHealth = 2f;
    float damageMieszko = 0.25f;
    public bool hasCollided = false;

	// Use this for initialization
	void Start () {
        actualEnemyHealth = maxEnemyHealth;
        mieszko = GameObject.FindGameObjectWithTag("Mieszko").GetComponent<MieszkoMovement>();
	}
	void Update () {
        HealthEnemy();
        AttackEnemy();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Mieszko")
        {
            hasCollided = true;
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mieszko")
        {
            hasCollided = false;
           

        }
    }
    
    public void AttackEnemy()
    {
        if ((hasCollided) && (mieszko.actualHealth >= 1))
        {
            enemy.SetBool("is_enemy_attacking", true);
            enemy.SetBool("is_enemy_stand", false);
            mieszko.DamageFromEnemy(damageMieszko * Time.deltaTime);
            

        }
        else
        {
            StandEnemy();
            
        }        
    }
    void StandEnemy()
    {
        enemy.SetBool("is_enemy_attacking", false);
        enemy.SetBool("is_enemy_stand", true);
    }
    public void DamageFromMieszko(float injury)
    {
        actualEnemyHealth -= injury * Time.deltaTime;
    }
    public void HealthEnemy()
    {
        if (actualEnemyHealth > maxEnemyHealth)
        {
            actualEnemyHealth = maxEnemyHealth;
        }
        if (actualEnemyHealth <= 0)
        {
            GameObject temporaryItem = Instantiate(itemDrop, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            temporaryItem.transform.position = this.transform.position;
            DieEnemy();
        }
    }
    void DieEnemy()
    {

        Destroy(this.gameObject);
    }
}
