using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private Rigidbody bulletRigidbody;

    public int rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {

        speed = Random.Range(4f, 8f); //속도 4~8

        bulletRigidbody = GetComponent<Rigidbody>();

        bulletRigidbody.velocity = transform.right * speed;
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

    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);
    }
}