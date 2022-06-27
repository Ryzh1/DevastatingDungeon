using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public static int ScoreValue = 0;
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
        score.text = "Score: " + ScoreValue;

        if(Player.CurrentHealth <= 0)
        {
            ScoreValue = 0;
        }
    }
}
