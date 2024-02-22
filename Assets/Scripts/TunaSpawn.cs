using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunaSpawn : MonoBehaviour
{
    public GameObject tunaPrefab;
    public float lifetime = 3.0f; // initial lifetime of tuna is 3 seconds
    // change below to bounds for quad (new gameobject) bc this is tacky and non-portable lol
    public int minX = -33, maxX = 38, minY = -16, maxY = 18;


    void Start()
    {
        StartCoroutine(DecreaseLifetime());
        StartCoroutine(SpawnTunas());
    }

    void Update()
    {
        if (GameController.isGameOver) return;
    }

    // for decreasing time of tuna onscreen every 10 seconds (for difficulty!)
    IEnumerator DecreaseLifetime()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            if (lifetime > 0.1) // Ensure lifetime doesn't go below 0.1 second
            {
                lifetime /= 2;
            }
        }
    }

    // for spawning tunas + adjust difficulty
    IEnumerator SpawnTunas()
    {
        // while (true)
        while (!GameController.isGameOver)
        {
            GameObject tuna = SpawnTuna();
            Destroy(tuna, lifetime); // destroy instance after lifetime secs

            yield return new WaitForSeconds(1); // wait 1 sec before spawning

        }
    }

    GameObject SpawnTuna()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(x, y, 0);
        GameObject tuna = Instantiate(tunaPrefab, spawnPos, Quaternion.identity);
        return tuna;
    }
    
}
