using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_EnemyType3 : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 100;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("TankFire");
        rb.velocity = -transform.right * speed;
        //Bullet can't destroy the object out of the Main Camera 
        Destroy(gameObject, 0.3f);
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        Destroy(gameObject);

    }
}
