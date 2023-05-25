using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        this.timeAfterSpawn = 0f;
        this.spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        this.target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {

        timeAfterSpawn += Time.deltaTime;

        if (this.timeAfterSpawn >= this.spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject bullet
                = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);

            bullet.transform.LookAt(target);

            this.spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}