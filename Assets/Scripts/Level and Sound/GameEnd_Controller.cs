using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameEnd_Controller : MonoBehaviour
{
    public bool endGame = false;
    public AudioSource win;

    public Player_Controller Player;

    void Start()
    {
        endGame = false;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        GameObject player = GameObject.Find("Player");
        Player = player.GetComponent<Player_Controller>();
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length <= 0 && endGame == false && Player.dead != true)
        {
            endGame = true;
            ScoreScript.ScoreValue = 0;
            PowerUpText_Controller.PUName = "";
            
            Destroy(GameObject.FindWithTag("PowerUp"));
            StartCoroutine(GameOver());

        }

    }

    IEnumerator GameOver()
    {
        SceneManager.LoadScene("GameOver");
        win.Play();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");
        Player.Credits = true;
        yield return new WaitForSeconds(0.01f);
        Destroy(this.gameObject);
        Destroy(GameObject.FindWithTag("Player"));

    }



}
