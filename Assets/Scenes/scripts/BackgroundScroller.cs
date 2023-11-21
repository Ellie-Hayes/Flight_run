using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public GameObject[] spawnableobjects;
    public GameObject[] pickups;
    public GameObject[] players;
    public GameObject coin;
    public GameObject playerSpawn;
    public bool run;
    public bool jetpack;


    private int side;
    private float spawncountdown = 2.5f;
    public float difficultycountdown = 2.5f;
    private float coincountdown = 20f;
    private float pickupcountdown;

    public float speed = 5f;
    public bool makeBlocksSmall;

    private void Start()
    {
        pickupcountdown = Random.Range(20f, 40f);

        int hatselected = PlayerPrefs.GetInt("PlayerHat");
        Instantiate(players[hatselected], playerSpawn.transform.position, Quaternion.identity);

        if (jetpack) { PlayerPrefs.SetInt("Gamemode", 1); }
        else { PlayerPrefs.SetInt("Gamemode", 0); }
        
    }
    // Update is called once per frame
    void Update()
    {
        //Countdown timers 
        spawncountdown -= Time.deltaTime;

        if (spawncountdown <= 0f)
        {
            if (jetpack) { Jetpack(); }
            if (run) { Run(); }

            spawncountdown = difficultycountdown;
        }

        difficultycountdown -= 0.05f * Time.deltaTime;
        if (!jetpack) { if (difficultycountdown <= 0.5f) { difficultycountdown = 0.5f; } }
        else { if (difficultycountdown <= 0.25f) { difficultycountdown = 0.25f; } }
        
        speed += 0.05f * Time.deltaTime;
        if (!jetpack) { if (speed >= 8) { speed = 8; } }
        else { if (speed >= 11) { speed = 11; } }
       
        
       
        coincountdown -= Time.deltaTime;
        if (coincountdown <= 0f) { spawncoin(); }

        pickupcountdown -= Time.deltaTime;
        if (pickupcountdown <= 0f) { spawnPickup(); }

    }

    void Jetpack()
    {
        int blocktype = Random.Range(0, spawnableobjects.Length);

        Instantiate(spawnableobjects[blocktype], new Vector3(15, Random.Range(-4, 4.5f), 0), Quaternion.identity);
    }

    void Run()
    {
        side = (int)Random.Range(1, 3);

        if (side == 1)
        {
            int blocktype1 = Random.Range(0, spawnableobjects.Length);
            Instantiate(spawnableobjects[blocktype1], new Vector3(15, Random.Range(-1.6f, -2), 0), Quaternion.identity);

        }

        if (side == 2)
        {
            int blocktype2 = Random.Range(0, spawnableobjects.Length);
            Instantiate(spawnableobjects[blocktype2], new Vector3(15, Random.Range(0, 0.5f), 0), Quaternion.identity);
        }


    }

    void spawncoin()
    {
        coincountdown = 20f;
        Instantiate(coin, new Vector3(15, Random.Range(-1.6f, 0.5f), 0), Quaternion.identity);
    }

    void spawnPickup()
    {
        int pickupToSpawn = (int)Random.Range(0, pickups.Length);
        Instantiate(pickups[pickupToSpawn], new Vector3(15, Random.Range(-1.6f, 0.5f), 0), Quaternion.identity);

        pickupcountdown = Random.Range(20f, 40f);
    }

    IEnumerator blockPickup()
    {
        yield return new WaitForSeconds(10f);
        makeBlocksSmall = false;
    }
    
}

