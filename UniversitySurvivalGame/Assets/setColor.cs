using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setColor : MonoBehaviour
{
    public Texture faceTexture; // �ܸ鿡 ���� �̹���
    public int targetFaceIndex; // �̹����� ���� ���� �ε���

    // Start is called before the first frame update
    void Start()
    {
        SetFaceTexture(faceTexture, targetFaceIndex);
    }

    // �鿡 �̹����� ������ �Լ�
    void SetFaceTexture(Texture texture, int faceIndex)
    {
        MeshRenderer cubeRenderer = GetComponent<MeshRenderer>();

        // ��ȿ�� �� �ε������� Ȯ��
        if (faceIndex < 0 || faceIndex >= cubeRenderer.materials.Length)
        {
            Debug.LogError("Invalid face index!");
            return;
        }

        // �ش� ���� ������ �ؽ�ó�� �Ҵ�
        cubeRenderer.materials[faceIndex].mainTexture = texture;
    }
}
