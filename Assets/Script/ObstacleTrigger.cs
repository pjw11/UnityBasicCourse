using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

    }

    private void OnTriggerEnter(Collider other)
    {
        meshRenderer.material.color = Random.ColorHSV();
        Debug.Log($"{other.name}������Ʈ�� �浹 ����");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"{other.name}������Ʈ�� �浹 ��...");

    }

    private void OnTriggerExit(Collider other)
    {
        meshRenderer.material.color = Color.white;
        Debug.Log($"{other.name}������Ʈ�� �浹 ����");

    }
}
