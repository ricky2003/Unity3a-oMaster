using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class Positions : MonoBehaviour
{
    public List<CaracterPosition> positions;

    public Positions()
    {
        positions=new List<CaracterPosition>();
    }
}
