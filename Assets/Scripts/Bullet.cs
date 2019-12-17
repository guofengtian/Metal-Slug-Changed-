using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb; 


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        //Bullet can't destroy the object out of the Main Camera 
        Destroy(gameObject, 0.3f);
    }
    

        private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        if(hitInfo.name == "Tank") 
        {
            Tank tank = hitInfo.GetComponent<Tank>();
            if (tank != null)
            {
                tank.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (hitInfo.name == "Boss")
        {
            Boss boss = hitInfo.GetComponent<Boss>();
            if (boss != null)
            {
                boss.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null) 
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }


}
