using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSoju : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f; // �����̴� �ӵ�
    public float distance; // �պ� �Ÿ�

    private float startPosX; // ���� ��ġ X ��ǥ

    private void Start()
    {
        startPosX = transform.position.z; // ���� ��ġ ����
    }

    private void Update()
    {
        // �¿�� �պ� �
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
        Debug.Log("����å�� �浹�� ��ü :" + other);
    }
}
