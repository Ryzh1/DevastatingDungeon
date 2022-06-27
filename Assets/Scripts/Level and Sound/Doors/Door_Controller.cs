using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Door_Controller : MonoBehaviour
{
    public string Level;
    public Sprite OpenedDoor;
    public Vector2 SpawnLocation;


    void Update()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length <= 0)
        {
            OpenDoor();

        }

    }

    public void OpenDoor()
    {

        GetComponent<SpriteRenderer>().sprite = OpenedDoor;
        GetComponent<BoxCollider2D>().isTrigger = true;


    }

    // When triggered find with tag enemy and player and get the player controller and shooting script.
    // Stop power ups when going through the door.
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject Player = GameObject.Find("Player");
        Transform spawn = Player.GetComponent<Transform>();


        if (enemy.Length <= 0)
        {    

            if (other.tag == "Player")
            {
                SceneManager.LoadScene(Level, LoadSceneMode.Single);
                spawn.position = SpawnLocation;
            }
        }
    }
}
