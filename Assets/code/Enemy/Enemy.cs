using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMechine stateMachine;
    private NavMeshAgent agent;

    public NavMeshAgent Agent { get => agent; }
    public Path path;

    //just for debugging 
    [SerializeField]
    private string currentState;

    void Start()
    {
        stateMachine = GetComponent<StateMechine>();    
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
    }

    void Update()
    {
        
    }
}
