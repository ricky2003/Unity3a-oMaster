using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{

    void Update()
    {
        
    }
    public void OnColisionEnter(Collider other)//objeto que nos ha chocado 
    {
        Debug.Log("Detectado una colision");
    }
}
