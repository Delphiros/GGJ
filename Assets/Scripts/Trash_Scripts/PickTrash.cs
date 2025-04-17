using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PickTrash : MonoBehaviour
{
    RaycastHit hitInfo;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (Input.GetMouseButtonDown(0) && hitInfo.collider.CompareTag("Trash"))
            {
                Debug.Log("Hit" + hitInfo.collider.name);
                hitInfo.collider.GetComponent<Trash>().Interact();
            }

            
        }

    }

}
