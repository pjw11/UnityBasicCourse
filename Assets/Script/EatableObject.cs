using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatableObject : MonoBehaviour
{
    [SerializeField]
    private int itemIndex;
    public int ItemIndex => itemIndex;
}
