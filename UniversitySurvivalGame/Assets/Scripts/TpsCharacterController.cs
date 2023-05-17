using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpsCharacterController : MonoBehaviour
{   
    [SerializeField]
    private Transform characterBody;
    [SerializeField]
    private Transform cameraArm;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 camangle = cameraArm.rotation.eulerAngles;
        animator = characterBody.getComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move()
    {
        Debug.DrawRaycameraArm.forward
    }

    private void LookAround()
    {
        Vector3 camAngle = cameraArm.rotation.eulerAngles;

        cameraArm.rotation = Quarternion.Euler(camAngle.x, camAngle.y, camAngle.z);
    }
}
