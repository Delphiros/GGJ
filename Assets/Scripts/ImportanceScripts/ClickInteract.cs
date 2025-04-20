using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteract : MonoBehaviour
{
    RaycastHit hitInfo;
    //IInteract interact;
    private void Update()
    {
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
                }*/

            }


        }

    }
}
