using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Key_Script : MonoBehaviour
{
    public static int KeyValue = 0;
    Text key;


    // Start is called before the first frame update
    void Start()
    {
        key = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        Player_Controller Player = player.GetComponent<Player_Controller>();
        key.text = "Keys: " + KeyValue;



        if (Player.CurrentHealth <= 0)
        {
            KeyValue = 0;
        }
    }
}
