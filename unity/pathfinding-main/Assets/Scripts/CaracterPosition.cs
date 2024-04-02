using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaracterPosition 
{
    private  string name { get; set; }
    private float timeStamp { get; set; }
    private Vector3 position { get; set; }//forma de hacer getter y setters

    public CaracterPosition(string name, float timestatmp, Vector3 position)
    {
        this.name = name;
        this.position = position;
        this.timeStamp = timestatmp;
    }

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
