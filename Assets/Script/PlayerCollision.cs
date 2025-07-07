using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}오브젝트와 충돌 시작");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}오브젝트와 충돌 중...");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}오브젝트와 충돌 종료");

    }
}
