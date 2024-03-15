using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMechine : MonoBehaviour
{
    public BaceState activeState;
    public PetrolState petrolState;

    public void Initialise()
    {
        petrolState = new PetrolState();
        ChangeState(petrolState);
    }

    void Start()
    {
        
    }

    void Update()
    {
         if(activeState != null)
         {
            activeState.Perform();
         }
    }

    public void ChangeState(BaceState NewState)
    {
        //check activeState != null
        if(activeState != null)
        {
            //run cleanup on activeState
            activeState.Exit();
        }

        //change to a new state 
        activeState = NewState;

        //fail-Safe null check to make sute a new state wasn's null
        if (activeState != null)
        {
            //Setup new state
            activeState.stateMechine = this;

            activeState.enemy = GetComponent<Enemy>();

            activeState.Enter();
        }
    }
}
