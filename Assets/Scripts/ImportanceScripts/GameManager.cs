using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int[] ListLevelAmountMax = { 8, 10, 12 };
    public int MaxTrashCollected { get; private set; }
    public int currentTrashCollected { get; private set; }
    public TextMeshProUGUI TrashCount;
    public int Level { get; private set; }

    public bool IsChangeColor = false;

    [SerializeField] List<Trash> _listAllTrashHere = new List<Trash>();
    private int numListTrashForHint = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    private void Start()
    {
        Level = 1;

        MaxTrashCollected = _listAllTrashHere.Count;
        TrashCount.text = currentTrashCollected + "/" + MaxTrashCollected;
    }


    #region Trash

    private void SetLevelTrash(int numLevel)
    {
        MaxTrashCollected = ListLevelAmountMax[numLevel-1];
    }

    public void GetTrash()
    {
        currentTrashCollected++;
        TrashCount.text = currentTrashCollected + "/3";
    }

    public void UpdateNumberTrashCount(string text)
    {
        TrashCount.text = text;
    }
    
    public void PlayHint()
    {
        if (numListTrashForHint < _listAllTrashHere.Count)
        {
            _listAllTrashHere[numListTrashForHint].PlayHint();
            numListTrashForHint++;
        }
        else Debug.LogWarning("That's All Trash Have");

    }

    #endregion
}
