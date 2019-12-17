using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 100;
    public Animator animator;

    public Slider slider;

    public GameObject deathEffect;

    void Start()
    {
        animator = GetComponent<Animator>();
        slider.value = 1.0f;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        slider.value = (float) health / 100;

        if (health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("PlayerDie");
            animator.SetBool("Dying", true);
            Die();
           
        }
    }

    public void TakeHealing(int aid)
    {
        health += aid;
      
        slider.value = (float)health / 100;

        if (health > 100)
        {
            health = 100;
        }
    }



    void Die()
    {

        //Debug.Log("die");

        //FindObjectOfType<AudioManager>().Play("");

        //Destroy object after 1.2 seconds, let animation_die play
        Destroy(gameObject, 1.2f);
        StartCoroutine(Delay.DelayToInvoke(() =>
        {
            Application.LoadLevel("Failed");
        }, 1.15f));

    }
}
