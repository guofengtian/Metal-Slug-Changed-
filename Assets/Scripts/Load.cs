using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public int scene;

    bool loaded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!loaded) 
        {
            //Debug.Log(collision);
          
            if (collision.name == "Gate") 
            {
                SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

                loaded = true;

                collision.gameObject.SetActive(false);
            }
            
        }
    }


}
