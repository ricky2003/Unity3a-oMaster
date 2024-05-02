using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]

public class CaracterPosition 
{
    public string name;
    public float timeStamp;
    public Vector3 position;//forma de hacer getter y setters

    public CaracterPosition(string name, float timestatmp, Vector3 position)
    {
        this.name = name;
        this.position = position;
        this.timeStamp = timestatmp;
    }
    public CaracterPosition() { }

    public override string ToString()
    {
        return $" {name} ; {timeStamp} ; {position}";//interpolited string
        //return name + " " + timeStamp + " " + position;
        
    }
    public string ToCSV()
    {
        return $" {name} ; {timeStamp} ; {position.x} ; {position.y} ; {position.z}";//interpolited string
                                                 

    }
}
