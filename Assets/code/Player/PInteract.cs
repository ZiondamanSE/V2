using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PInteract : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private float distance = 3f;

    [SerializeField]
    private LayerMask mask;
    private PUI playerUI;

    private InputManeger inputManager;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PLook>().cam;
        playerUI = GetComponent<PUI>();
        inputManager = GetComponent<InputManeger>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);

        // Create a ray at the center of the camera, shooting outwards.
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance,mask))
        {
            if(hitInfo.collider.GetComponent<Interacteble>() != null) 
            {
                Interacteble interacteble = hitInfo.collider.GetComponent<Interacteble>();
                playerUI.UpdateText(interacteble.promptMessage);
                if (inputManager.onFoot.Interact.triggered)
                {
                    interacteble.BaseInteract();
                }
            }
        }
    }
}
