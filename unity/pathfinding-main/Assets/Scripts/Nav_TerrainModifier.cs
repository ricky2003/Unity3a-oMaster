using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Nav_TerrainModifier : MonoBehaviour
{
    private NavMeshModifier _meshSurface;
    // Start is called before the first frame update
    void Start()//aqui quitar velocidad cuando entre
    {
        _meshSurface=GetComponent<NavMeshModifier>();
    }


    private void OntriggeresEnter(Collider other){
        Debug.Log("enter");
        if(other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent)){
            if(_meshSurface.AffectsAgentType(agent.agentTypeID)){
             agent.speed /= NavMesh.GetAreaCost(_meshSurface.area);
            }
        }   
    }
    private void OntriggeredExit(Collider other){
        Debug.Log("exit");

        if(other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent)){
            if(_meshSurface.AffectsAgentType(agent.agentTypeID)){
             agent.speed *= NavMesh.GetAreaCost(_meshSurface.area);
            }
        }
    
    }
}
