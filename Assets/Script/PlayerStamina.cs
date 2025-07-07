using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField]
    private MovementCharactorController movement;
    [SerializeField]
    private float max = 100;
    private float current;
    private float normalRecovery = 1.0f;
    private float decreaseWhenRun = 5.0f;
    private float emergencyRecovery = 20.0f;

    public float Max => max;
    public float Current => current;

    public bool IsEmergencyMode { set; get; } = false;

    private void Awake()
    {
        current = max;
    }
    private void Update()
    {
        Recovery ();
        current += Time.deltaTime * normalRecovery;

        if(movement.MoveSpeed > 2)
        {
            current -= Time.deltaTime * decreaseWhenRun;
        }
        if(current<=0)
        {
            IsEmergencyMode = true;
        }
        current = Mathf.Clamp(current, 0, max);
    }

    private void Recovery()
    {
        if(IsEmergencyMode==true)
        {
            current += Time.deltaTime * emergencyRecovery;

            if(current >= max)
            {
                IsEmergencyMode = false;
            }
        }
        else
        {
            current += Time.deltaTime * normalRecovery;
        }
    }
}
