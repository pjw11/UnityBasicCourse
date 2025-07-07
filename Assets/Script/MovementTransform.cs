using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTransform : MonoBehaviour
{
    private float moveSpeed = 3;
    private Vector3 moveDirection;
    private void Awake()
    {
        moveSpeed = 5;
        moveDirection = Vector3.right;
    }
    /*
    private void Awake()
    {
        transform.position = transform.position + new Vector3(1, 0, 0) * 1;
    }
    */
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(x, 0, z);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
