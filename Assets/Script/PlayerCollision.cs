using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}������Ʈ�� �浹 ����");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}������Ʈ�� �浹 ��...");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}������Ʈ�� �浹 ����");

    }
}
