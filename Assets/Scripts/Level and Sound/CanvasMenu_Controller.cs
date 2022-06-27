using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CanvasMenu_Controller : MonoBehaviour
{
    private Transform canvas;

    public GameObject mainmenu;
    public GameObject options;
    public GameObject credits;
    public GameObject controls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        Player_Controller Player = player.GetComponent<Player_Controller>();


        if (Player.Credits == true)

        {
            mainmenu.SetActive(false);
            options.SetActive(false);
            controls.SetActive(false);
            credits.SetActive(true);
            Player.Credits = false;
        }
    }
}
