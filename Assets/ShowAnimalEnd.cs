using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAnimalEnd : MonoBehaviour
{
    public List<GameObject> _animals = new List<GameObject>();
    public void ShowAnimalEndd()
    {
        foreach (GameObject _animal in _animals) { 
            _animal.SetActive(true);
        }
    }
}
