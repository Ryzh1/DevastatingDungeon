using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BossDoor_Controller : MonoBehaviour
{
    public Sprite OpenedDoor;
    public Vector2 SpawnLocation;

    private int RandomBoss;


    void Update()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length <= 0 && Key_Script.KeyValue == 2)
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

            if (Key_Script.KeyValue == 2 && other.tag == "Player")
            {

                Key_Script.KeyValue = 0;
                SceneManager.LoadScene("BossRoom1");
                spawn.position = SpawnLocation;
            }
        }
    }
               
}
