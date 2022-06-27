using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    public string GOName = "";
    Text gameOver;



    // Start is called before the first frame update
    void Start()
    {
        gameOver = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        gameOver.text = GOName;
    }
}
