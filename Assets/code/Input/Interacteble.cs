using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interacteble : MonoBehaviour
{
    //Add or remove an InteractionEvent component to this gameObject
    public bool useEvents;

    // message Displayed to players when looking at an interactable.
    public string promptMessage;

    // This Function will be called form our player
    public void BaseInteract()
    {
        if(useEvents)
        {
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        }
        Interact();
    }

    protected virtual void Interact()
    {
        // We wont have any code written in this function 
        // This is a template funtion to be overridden by our subclass
    }
}
