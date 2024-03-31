using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class Nav_MoveToGrip : MonoBehaviour
{
    public Camera cam;
    private NavMeshAgent agent;
    public Transform player;
    private int puntuacion;
    public Text puntosTexto;
   

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        puntuacion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coins"))
        {
            other.GetComponent<GameManager>();
            Debug.Log("Moneda encontrada");
            puntuacion++;
            puntosTexto.text = puntuacion.ToString();
            Destroy(other.gameObject);
        }

    }








}
