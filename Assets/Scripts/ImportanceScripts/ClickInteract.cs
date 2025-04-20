using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteract : MonoBehaviour
{
    RaycastHit hitInfo;
    //IInteract interact;
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);

            if (hits.Length > 0)
            {
                foreach (RaycastHit hit in hits)
                {
                    Debug.Log("Hit Object: " + hit.collider.gameObject.name);

                    IInteract[] interactables = hit.collider.GetComponents<IInteract>();

                    if (interactables != null && interactables.Length > 0)
                    {
                        foreach (IInteract interactable in interactables)
                        {
                            Debug.Log("  - Calling Interact on: " + interactable.GetType().Name);
                            interactable.Interact();
                        }
                    }
                }
            }
        }


        /*
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Hit" + hitInfo.collider.name);

                IInteract[] interacts = hitInfo.collider.GetComponents<IInteract>();

                if (interacts != null && interacts.Length > 0)
                {
                    foreach (IInteract interactable in interacts)
                    {
                        interactable.Interact();
                    }
                }
                
                /*if (hitInfo.collider.TryGetComponent(out IInteract _interact))
                {
                    _interact.Interact();
                }#1#

            }


        }
        */

    }
}
