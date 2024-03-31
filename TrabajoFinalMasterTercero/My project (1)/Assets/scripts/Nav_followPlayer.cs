using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Nav_followPlayer : MonoBehaviour
{

    public Transform player;
    private NavMeshAgent agent;
   


    // Start is called before the first frame update
    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);//los atributos que tiene el transform lo que cojemos en esta caso es su posicion
        

    }
   
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
