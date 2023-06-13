using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bulletSpawner;


    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < bulletSpawner.Length;i++ )
            bulletSpawner[i].SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Player playerController = other.GetComponent<Player>();
            if (playerController != null)
            {
                for (int i = 0; i < bulletSpawner.Length; i++)
                    bulletSpawner[i].SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            Player playerController = other.GetComponent<Player>();
            if(playerController!=null)
            {
                for (int i = 0; i < bulletSpawner.Length; i++)
                    bulletSpawner[i].SetActive(false);
            }
        }
    }
}
