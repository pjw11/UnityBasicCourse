using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private float distance;
    private float xAxisSpeed = 400.0f;
    private float yAxisSpeed = 1000.0f;
    private float xAxisLimitMin = 5.0f;
    private float xAxisLimitMax = 80.0f;
    private float x, y;

    private float distanceMin = 2.0f;
    private float distanceMax = 50.0f;
    private float wheelSpeed = 1000.0f;

    private void Awake()
    {
        distance = Vector3.Distance(transform.position, target.position);
        
        Vector3 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;
    }

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            UpdateRotate();
        }
        UpdateZoom();
    }

    private void LateUpdate()
    {
        if (target == null) return;

        transform.position = target.position + transform.rotation * new Vector3(0, 0, -distance);
    }
    private void UpdateRotate()
    {
        //마우스의 y 축 위치 변화를 바탕으로 카메라의 x축 회전 값 설정
        x -= Input.GetAxisRaw("Mouse Y") * xAxisSpeed * Time.deltaTime;
        //마우스의 x 축 위치 변화를 바탕으로 카메라의 y축 회전 값 설정
        y += Input.GetAxisRaw("Mouse X") * yAxisSpeed * Time.deltaTime;

        x = ClampAngle(x, xAxisLimitMin, xAxisLimitMax);

        transform.rotation = Quaternion.Euler(x, y, 0);
    }
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }

    private void UpdateZoom()
    {
        distance -= Input.GetAxisRaw("Mouse ScrollWheel") * wheelSpeed * Time.deltaTime;
        distance = Mathf.Clamp(distance, distanceMin, distanceMax);
    }
}
