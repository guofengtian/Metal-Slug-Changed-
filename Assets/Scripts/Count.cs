using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Count : MonoBehaviour
{
    public Text countText;
    public int count;


    void Start()
    {
        count = 0;
        countText.text = "KILL TANK!!!";
        
    }


    void Update()
    {
        CountScore(count);
        if (count == 40)
        countText.text = "YOU MADE IT";
    }

    void CountScore(int score)
    {
        count = score;
    }
    
    

}
