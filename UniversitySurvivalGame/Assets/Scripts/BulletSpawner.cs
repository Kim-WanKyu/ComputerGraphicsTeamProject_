using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;  // 총알 프리팹
    public int bulletCount;  // 생성할 총알 개수

    private float spawnerZLength;  // 스포너의 z축 길이 //장애물 생성되는 범위 길이

    private float spawnLate;

    private void Start()
    {
        // 스포너 생성   //스포너의 장애물 생성 범위 초기화
        spawnerZLength = transform.localScale.z;

        spawnLate = 4.5f;
    }

    private void Update()
    {
        spawnLate += Time.deltaTime;
        if (spawnLate > 5f)
        {
            SpawnBullets();
            spawnLate = 0;
        }
    }

    private void SpawnBullets()
    {
        bulletCount = (int) (spawnerZLength / 5);
        for (int i = 0; i < bulletCount; i++)
        {
            // 총알 생성
            float zPosition = transform.position.z - (spawnerZLength / 2) + (spawnerZLength/bulletCount * i);  //시작 위치 + 간격
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y, zPosition);
            Quaternion bulletRotation = transform.rotation;
            GameObject bullet = Instantiate(bulletPrefab, bulletPosition, bulletRotation);
        }
    }
}