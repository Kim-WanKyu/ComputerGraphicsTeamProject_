using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSoju : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f; // 움직이는 속도
    public float distance; // 왕복 거리

    private float startPosX; // 시작 위치 X 좌표

    private void Start()
    {
        startPosX = transform.position.z; // 시작 위치 설정
    }

    private void Update()
    {
        // 좌우로 왕복 운동
        float newPos = startPosX + Mathf.Cos(Time.time * speed) * distance;
        transform.position = new Vector3(transform.position.x, transform.position.y, newPos);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player playerController = other.GetComponent<Player>();
            if (playerController != null)
            {
                playerController.Hit();
            }
        }
        Debug.Log("전공책과 충돌한 물체 :" + other);
    }
}
