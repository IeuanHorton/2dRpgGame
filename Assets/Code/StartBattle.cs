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
    private float attackRange = 0;

    [SerializeField]
    private int damage = 0;//Prob uneeded

    [SerializeField]
    private Transform attackPos;
    [SerializeField]
    private LayerMask whatIsEnemies;//Could be unneeded, but could also collect what enemy was dectected

    // I don't think this way of doing it will work for the game
    [SerializeField]
    private float attackRangeX;
    [SerializeField]
    private float attackRangeY;

    private void Start()
    {
        timeBetweenAttack = maxTimeBetweenAttack;
    }

    private void Update()
    {
        if(timeBetweenAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position ,new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);//Collects an array of what is inside the hit zone
            }
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }


}
