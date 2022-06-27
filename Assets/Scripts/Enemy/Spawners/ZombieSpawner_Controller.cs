using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner_Controller : MonoBehaviour
{

    public int ZombieSpawnerMaxHealth = 100;
    public bool IsInvincible;


    public int ZombieSpawnerCurrentHealth;
    private SpriteRenderer spriterenderer;
    private Rigidbody2D rb;

    public float SpawnRate = 5f;
    public GameObject Zombie;

    public bool IsSpawning;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();

        ZombieSpawnerCurrentHealth = ZombieSpawnerMaxHealth;

        

    }

    // Update is called once per frame
    void Update()
    {

        
        if (ZombieSpawnerCurrentHealth <= 0)
        {
            ScoreScript.ScoreValue += 5;
            Destroy(gameObject);

        }


        if(IsSpawning == false)
        {
            StartCoroutine("Delay", SpawnRate);
        }

    }

    //Health
    public void ChangeHealth(int amount)
    {

        ZombieSpawnerCurrentHealth = Mathf.Clamp(ZombieSpawnerCurrentHealth + amount, 0, ZombieSpawnerMaxHealth);

        Debug.Log(ZombieSpawnerCurrentHealth + "/" + ZombieSpawnerMaxHealth);

    }


    // SPawner
    IEnumerator Delay(float delay)
    {

        // Spawn zombie every few seconds.
        IsSpawning = true;

        Instantiate(Zombie, transform.position, transform.rotation);
        yield return new WaitForSeconds(delay);

        IsSpawning = false;



    }
}
