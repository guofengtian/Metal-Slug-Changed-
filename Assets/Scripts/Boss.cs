using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人移动
/// </summary>
public class Boss : MonoBehaviour
{
    public int health = 100;
    public Animator animator;
    public GameObject deathEffect;

    public Transform PlayerTransform;
    public float speed = 6;
    public int step = 1;
    public int x = 0;

    public float velocity = 0.5f;
    public Rigidbody2D rd;
    private Vector3 NextPosition;

    private bool m_FacingRight = false;
    void Start()
    {
        NextPosition = transform.position;
        InvokeRepeating("EnemyMove", 1, velocity);
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        rd.MovePosition(Vector3.Lerp(transform.position, NextPosition, Time.deltaTime * speed));
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
        Destroy(gameObject, 0.7f);

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            animator.SetBool("Hiting", true);
            player.TakeDamage(100);
        }



    }

    public void EnemyMove()
    {
       
        Vector3 offset = PlayerTransform.position - transform.position;
       
        if (offset.magnitude > 4)
        {
            if (offset.x > 0 && !m_FacingRight)
             {
                animator.SetBool("Moving", true);
                x = step;
                Flip();

            }
            else if (offset.x < 0 && m_FacingRight)
            {
                animator.SetBool("Moving", true);
                x = -step;
                Flip();
            }


            NextPosition = transform.position + new Vector3(x, 0, 0);
        }
    }

    private void Flip()
    {

        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }


}
