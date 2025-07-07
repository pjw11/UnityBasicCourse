using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ItemData
{
    public Sprite icon;
    public string name;
    public int count;
    [TextArea(0, 30)]
    public string details;
    public int hpRecovery;
}
