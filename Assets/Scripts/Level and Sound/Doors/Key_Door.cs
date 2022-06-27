using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Key_Door : MonoBehaviour
{
    public string Level;
    public Sprite OpenedDoor;
    public Vector2 SpawnLocation;



    void Update()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length <= 0 && Key_Script.KeyValue == 1)
        {
            OpenDoor();
        }
    }


    public void OpenDoor()
    {

        GetComponent<SpriteRenderer>().sprite = OpenedDoor;
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject player = GameObject.Find("Player");
        Transform spawn = player.GetComponent<Transform>();

        if (enemy.Length <= 0)
        {
            if(Key_Script.KeyValue == 1 && other.tag == "Player")
            {
                Key_Script.KeyValue = 0;
                SceneManager.LoadScene(Level, LoadSceneMode.Single);
                spawn.position = SpawnLocation;
            }
        }

    }
}
