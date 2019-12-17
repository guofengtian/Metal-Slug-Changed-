using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    float horizontalMove = 0f;
    private float runSpeed = 4f;

    // Use this for initialization
    void Start()
    {
        
        offset = transform.position - player.transform.position;
        FindObjectOfType<AudioManager>().Play("Background");
    }

    // Update is called once per frame
    void Update()
    {
        //runSpeed = player.transform.position.x;
        if (-0.4f <= transform.position.x && transform.position.x <= 78.5f)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            if (Input.GetButtonDown("Crouch"))
            {
                runSpeed = runSpeed * 0.4f;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                runSpeed = 4f;
            }
            this.transform.Translate(horizontalMove * Time.fixedDeltaTime, 0, 0, Space.World);
        }
        
           
    }

}
