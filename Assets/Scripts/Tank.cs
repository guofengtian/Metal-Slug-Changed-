using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public int health = 100;
    public Animator animator;

    public GameObject deathEffect;
    public Transform sparkPoint;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(deathEffect, sparkPoint.position, sparkPoint.rotation);
        if (health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("TankDie");
            animator.SetBool("Dying", true);
            Die();
        }
    }

    void Die()
    {

        //Debug.Log("die");

        //Destroy object after 1.18 seconds, let animation_die play
        var sphere = GameObject.FindWithTag("Score");
        int message = 40;
        sphere.SendMessage("CountScore", message);


        Destroy(gameObject, 1.18f);

    }
}
