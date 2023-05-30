using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setColor : MonoBehaviour
{
    public Texture faceTexture; // 단면에 입힐 이미지
    public int targetFaceIndex; // 이미지를 입힐 면의 인덱스

    // Start is called before the first frame update
    void Start()
    {
        SetFaceTexture(faceTexture, targetFaceIndex);
    }

    // 면에 이미지를 입히는 함수
    void SetFaceTexture(Texture texture, int faceIndex)
    {
        MeshRenderer cubeRenderer = GetComponent<MeshRenderer>();

        // 유효한 면 인덱스인지 확인
        if (faceIndex < 0 || faceIndex >= cubeRenderer.materials.Length)
        {
            Debug.LogError("Invalid face index!");
            return;
        }

        // 해당 면의 재질에 텍스처를 할당
        cubeRenderer.materials[faceIndex].mainTexture = texture;
    }
}
