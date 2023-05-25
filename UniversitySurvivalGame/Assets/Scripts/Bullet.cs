using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public int damage;
    private Rigidbody bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();

        // 캐릭터 방향으로 생성
        Vector3 playerDirection = FindObjectOfType<Player>().transform.forward;
        bulletRigidbody.velocity = playerDirection * speed;

        Destroy(gameObject, 4f); // 4초 후에 파괴
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 충돌 처리
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

        Destroy(gameObject); // 충돌 후 총알 파괴
    }
}
