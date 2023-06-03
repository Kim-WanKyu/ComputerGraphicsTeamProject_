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
        speed = 8f;

        bulletRigidbody = GetComponent<Rigidbody>();

        bulletRigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, 10f);
        // 10초 후에 파괴 // 추후에 맵에 맞추어 수정 필요
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
            Destroy(gameObject);
            Debug.Log("총알과 충돌한 물체 :" + other);
        }
    }
}