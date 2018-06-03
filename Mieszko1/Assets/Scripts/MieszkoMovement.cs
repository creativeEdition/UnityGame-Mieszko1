using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



public class MieszkoMovement : MonoBehaviour {

    public static Rigidbody2D body_mieszko;
    public static Animator animation_mieszko;
    public GameObject MenagerUI;
   // private GameObject[] enemys;
   // private Enemy enemy;
    private GameObject singleEnemy;
    private Monument monument;
    private ButtonHandler buttonHandler;
    
    // Mieszko statics
    public float actualHealth;
    public float maxHealth = 3.99f;
    private float damageEnemy = 0.60f;
    private float damageMonument = 0.50f;

    //Bool statements
    public bool canAttack = false;
    private bool isThisMonument = false;
    public bool attack;
    public bool hasCollided = false;
    public bool isThisWife = false;
   // public bool isNpcTalk = false;
    GameObject closestEnemy = null;
    // Use this for initialization
    void Start () {
        actualHealth = maxHealth;
        body_mieszko = this.GetComponent<Rigidbody2D>();
        animation_mieszko = this.GetComponent<Animator> ();

       // enemys = GameObject.FindGameObjectsWithTag("enemy");
 
        
        buttonHandler = GameObject.FindGameObjectWithTag("attack").GetComponent<ButtonHandler>();
	}
    // Update is called once per frame
    void Update()
    {
        Move();
        Health();
        Attack();
        FindClosestEnemy();
        Regeneration();
        AttackMonument();
    }
    void Move()
    {
        float x_vector = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float y_vector = CrossPlatformInputManager.GetAxisRaw("Vertical");


        Vector2 vector_movement = new Vector2(x_vector, y_vector);

        if (vector_movement == Vector2.zero)
        {
            animation_mieszko.SetBool("is_mieszko_walking", false);
            animation_mieszko.SetBool("is_mieszko_attack", false);
        }
        else
        {
            if(x_vector < -0.1f)
            {
                transform.localScale = new Vector3(4, 4);
                animation_mieszko.SetBool("is_mieszko_walking", true);
                animation_mieszko.SetBool("is_mieszko_attack", false);
                animation_mieszko.SetFloat("x_position", vector_movement.x);
                animation_mieszko.SetFloat("y_position", vector_movement.y);
            }
            if(x_vector > 0.1f)
            {
                transform.localScale = new Vector3(-4, 4);
                animation_mieszko.SetBool("is_mieszko_walking", true);
                animation_mieszko.SetBool("is_mieszko_attack", false);
                animation_mieszko.SetFloat("x_position", vector_movement.x);
                animation_mieszko.SetFloat("y_position", vector_movement.y);
            }

        }

        body_mieszko.MovePosition(body_mieszko.position + vector_movement * Time.deltaTime * 4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "enemy")
        {
            hasCollided = true;
            canAttack = true;
            isThisMonument = false;
            FindObjectOfType<AudioManager>().Stop("musicBackground");
            FindObjectOfType<AudioManager>().PlaySounds("musicFight");

        }
        if (collision.gameObject.tag == "pomnik")
        {
            canAttack = true;
            isThisMonument = true;
        }
        if(collision.gameObject.tag == "wife")
        {
            isThisWife = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "enemy")
        {
            
            hasCollided = false;
            canAttack = false;
            animation_mieszko.SetBool("is_mieszko_walking", true);
            animation_mieszko.SetBool("is_mieszko_attack", false);
            FindObjectOfType<AudioManager>().Stop("musicFight");
            FindObjectOfType<AudioManager>().PlaySounds("musicBackground");
        }
        if(collision.gameObject.tag == "pomnik")
        {
            hasCollided = false;
            canAttack = false;
            animation_mieszko.SetBool("is_mieszko_walking", true);
            animation_mieszko.SetBool("is_mieszko_attack", false);
        }
        isThisWife = false;
        //isNpcTalk = false;
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] enemys;
        enemys = GameObject.FindGameObjectsWithTag("enemy");
        
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject enemy in enemys)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closestEnemy = enemy;
                distance = curDistance;
            }
        }
        return closestEnemy;
    }
    void Attack()
    {
        if ((canAttack == true) && (actualHealth >= 1) && (isThisMonument == false))
        {
            Debug.Log("mieszko możesz atakować");
            if (buttonHandler.click_attack == true)
            {
                if(closestEnemy!= null)
                {
                    buttonHandler.SetDownState();
                    animation_mieszko.SetBool("is_mieszko_attack", true);
                    closestEnemy.GetComponent<Enemy>().DamageFromMieszko(damageEnemy);
                }
                Debug.Log("HIT! HIT!");
            }
        }
    }
    void AttackMonument()
    {
        if ((isThisMonument == true) && (actualHealth >= 1) && (canAttack == true))
        {
            monument = GameObject.FindGameObjectWithTag("pomnik").GetComponent<Monument>();
            Debug.Log("mieszko możesz atakować");
            if (buttonHandler.click_attack == true)
            {
                animation_mieszko.SetBool("is_mieszko_attack", true);
                monument.DamageMonument(damageMonument);
                Debug.Log("HIT! HIT!");
            }
        }
    }
    public void DamageFromEnemy(float injury)
    {
        actualHealth -= injury;
        gameObject.GetComponent<Animation>().Play("damage_mieszko");

    }
    public void Health()
    {
        if (actualHealth > maxHealth)
        {
            actualHealth = maxHealth;
        }
        if (actualHealth <= 1)
        {
            Die();
        }
    }

    public void Die()
    {
        //function activates diePanel, which  allows to restart or exit game
        animation_mieszko.SetBool("is_mieszko_walking", false);
        MenagerUI.GetComponent<GUIController>().DieEvent();
    }
    public void Regeneration()
    {
        if ((hasCollided == false) && (actualHealth < maxHealth) && (actualHealth > 1))
        {
            actualHealth += 0.001f;

        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Mieszko Kolizja");
    }
}


