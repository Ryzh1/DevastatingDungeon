using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerUpText_Controller : MonoBehaviour
{
    public static string PUName = "";
    Text score;



    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        Player_Controller Player = player.GetComponent<Player_Controller>();
        score.text = PUName;

        if (Player.CurrentHealth <= 0)
        {
            PUName = "";
        }
        

    }
}
