using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChortSpawner_Controller : MonoBehaviour
{

    public int ChortSpawnerMaxHealth = 100;
    public bool IsInvincible;


    public int ChortSpawnerCurrentHealth;
    private SpriteRenderer spriterenderer;
    private Rigidbody2D rb;

    public float SpawnRate = 5f;
    public GameObject Chort;

    public bool IsSpawning;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();

        ChortSpawnerCurrentHealth = ChortSpawnerMaxHealth;



    }

    // Update is called once per frame
    void Update()
    {

        if (ChortSpawnerCurrentHealth <= 0)
        {
            ScoreScript.ScoreValue += 10;
            Destroy(gameObject);

        }


        if (IsSpawning == false)
        {
            StartCoroutine("Delay", SpawnRate);
        }

    }

    //Health
    public void ChangeHealth(int amount)
    {

        ChortSpawnerCurrentHealth = Mathf.Clamp(ChortSpawnerCurrentHealth + amount, 0, ChortSpawnerMaxHealth);

        Debug.Log(ChortSpawnerCurrentHealth + "/" + ChortSpawnerMaxHealth);

    }


    // SPawner
    IEnumerator Delay(float delay)
    {

        // Spawn zombie every few seconds.
        IsSpawning = true;

        Instantiate(Chort, transform.position, transform.rotation);
        yield return new WaitForSeconds(delay);

        IsSpawning = false;



    }
}

