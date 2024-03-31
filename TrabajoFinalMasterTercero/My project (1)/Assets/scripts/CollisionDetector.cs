using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    public GameObject player;
    public GameObject cazador;
    public GameObject patrols;

    private void OnTriggerStay(Collider other)//objeto que nos ha chocado 
    {
        
        if (other.CompareTag("Player"))
        {
            other.GetComponent<GameManager>();
            Debug.Log("Detectado una colision");

            SceneManager.LoadScene("EndGame");
        }
    }
    

}
