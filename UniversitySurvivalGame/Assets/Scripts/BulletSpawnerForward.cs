using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletSpawnerForward : MonoBehaviour
{
    public GameObject bulletPrefab;  // 총알 프리팹
    public int bulletCount;  // 생성할 총알 개수

    private float spawnerXLength;  // 스포너의 x축 길이 //장애물 생성되는 범위 길이

    private float spawnLate;

    private void Start()
    {
        // 스포너 생성   //스포너의 장애물 생성 범위 초기화

        spawnerXLength = transform.localScale.x;

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
        bulletCount = (int)(spawnerXLength / 4);
        for (int i = 0; i < bulletCount; i++)
        {
            // 총알 생성
            float xPosition = transform.position.x - (spawnerXLength / 2) + (bulletCount * i);  //시작 위치 + 간격

            Vector3 bulletPosition = new Vector3(xPosition, transform.position.y, transform.position.z);

            Quaternion bulletRotation = transform.rotation.normalized;

            GameObject bullet = Instantiate(bulletPrefab, bulletPosition, bulletRotation);
            bullet.transform.right = -transform.forward;
        }
    }
}