using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacleSpawner : MonoBehaviour
{

    public GameObject fallingObject;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    //���� ���� �߰�
    public Vector3 spawnPosition;
    public Quaternion spawnRotation;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        this.timeAfterSpawn = 0f;
        this.spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        this.target = FindObjectOfType<Player>().transform;
        spawnPosition = transform.position;
    }
    // 기타 필요한 함수들...

    void Update()
    {
        // 테스트용으로 키 입력을 통해 장애물을 생성할 수 있도록 합니다.

        timeAfterSpawn += Time.deltaTime;
        spawnPosition = new Vector3(Random.Range(transform.position.x - 10f, transform.position.x + 10), transform.position.y, transform.position.z);
        
        if (this.timeAfterSpawn >= this.spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject FallingObject = Instantiate(this.fallingObject, spawnPosition, this.transform.rotation);
            fallingObject.transform.position = spawnPosition;
            Destroy(FallingObject, 4);
            this.spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}

