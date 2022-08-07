using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattle : MonoBehaviour
{

    //Half way through this https://www.youtube.com/watch?v=1QfxdUpVh5I

    private float timeBetweenAttack;

    [SerializeField]
    private float maxTimeBetweenAttack = 0;
    [SerializeField]
    private LayerMask whatIsEnemies;//Could be unneeded, but could also collect what enemy was dectected

    // I don't think this way of doing it will work for the game
    [SerializeField]
    private float attackRangeX;
    [SerializeField]
    private float attackRangeY;
    [SerializeField]
    private Transform attackPos;

    private List<Collider2D> hitableEnemys = new List<Collider2D>();

    private void Start()
    {
        timeBetweenAttack = maxTimeBetweenAttack;
    }

    private void Update()
    {
        if(timeBetweenAttack <= 0)//Ensures that the player can not spam the attack button
        {
            if (Input.GetKey(KeyCode.Space))
            {
                foreach(Collider2D enemy in hitableEnemys)
                {
                    Vector2 distance = enemy.transform.position - this.transform.position;
                    Vector2 relativePosition = Vector2.zero;
                    relativePosition.x = Vector2.Dot(distance, this.transform.right.normalized);
                    relativePosition.y = Vector2.Dot(distance, this.transform.up.normalized);

                    Debug.Log("Relative Postion x :" + relativePosition.x + ", and y :" + relativePosition.y);
                }

                MoveToBattle(1);
            }
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    //Have enemy object enter the hitable list
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!hitableEnemys.Contains(collision))
            {
                hitableEnemys.Add(collision);
                Debug.Log("Added Enemy to list");
            }
        }
    }

    //Have enemy object leave the hitable list
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (hitableEnemys.Contains(collision))
            {
                hitableEnemys.Remove(collision);
                Debug.Log("Removed Enemy to list");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            MoveToBattle(2);
        }
    }

    //aggressor tells whether an enemy started the fight or the player did.
    private void MoveToBattle(byte aggressor)
    {
        //Change scene and move to battle
    }

}
