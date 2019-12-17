using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public Animator animator;

    public GameObject deathEffect;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
   
    public void TakeDamage(int damage) 
    {
        health -= damage;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        if (health <= 0) 
        {
            animator.SetBool("Dying", true);
            FindObjectOfType<AudioManager>().Play("EnemyDie");       
            Die();
        }
    }

    void Die() 
    {

        //Debug.Log("die");

        //Destroy object after 1.18 seconds, let animation_die play
        Destroy(gameObject,1.18f);
       
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(100);
        }
        

        //Debug.Log(hitInfo.name);
    }
}
