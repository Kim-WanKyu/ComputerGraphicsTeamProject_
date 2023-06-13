using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    //public float fallSpeed = 5f; // 장애물의 낙하 속도
    private float spawnRate;
   
    private void Update()
    {
        // 낙하하는 장애물의 위치를 업데이트
        //transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }
    void start()
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
            Destroy(gameObject);
            Debug.Log("총알과 충돌한 물체 :" + other);
        }
    }
}
