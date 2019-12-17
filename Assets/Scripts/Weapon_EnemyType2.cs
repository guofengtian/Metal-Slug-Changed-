using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon_EnemyType2 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool trigger = true;

    // Update is called once per frame
    void Update()
    {
        if (trigger == true)
        Shoot();
        
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        StartCoroutine(Wait());
    }
    

    public IEnumerator Wait()
    {
        trigger = false;
        yield return new WaitForSeconds(1.2f); // waits 1.2 second
        trigger = true; // will make the update method pick up 
    }
}
