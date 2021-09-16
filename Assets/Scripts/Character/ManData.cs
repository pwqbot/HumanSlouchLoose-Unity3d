using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ManData
{
    // Start is called before the first frame update
    public GameObject manPrefab;
    public ManType type;
    public int numLimit;
}

public enum ManType
{
    Yellow,
    Black,
    White
}
