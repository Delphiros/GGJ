using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int[] ListLevelAmountMax = { 8, 10, 12 };
    public int MaxTrashCollected { get; private set; }
    public int currentTrashCollected { get; private set; }
    public TextMeshProUGUI TrashCount;
    public int Level { get; private set; }

    [HideInInspector]
    public bool IsChangeColor = false;

    [SerializeField] 
    private SoundName _hintSound;

    [SerializeField] List<CheckTrash> _listAllTrashHere = new List<CheckTrash>();
    private int numListTrashForHint = 0;

    [SerializeField] private Animator _animatorUIFade;
    public GameObject _credit;

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

    public void GetTrash(SoundName sound,CheckTrash removeIt)
    {
        SoundManager.instance.Play(sound);

        currentTrashCollected++;
        TrashCount.text = currentTrashCollected + "/" + MaxTrashCollected;
        _listAllTrashHere.Remove(removeIt);
        if (currentTrashCollected >= MaxTrashCollected)
        {
            GameEnded();
        }
    }

    private void GameEnded()
    {
        //IsChangeColor = true;
        _animatorUIFade.enabled = true;
        SoundManager.instance.Play(SoundName.handpanBGM);
        UIManager.Instance.OpenEndGame();
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
        else
        {
            Debug.LogWarning("That's All Trash Have");
            numListTrashForHint = 0;
        }
        SoundManager.instance.Play(_hintSound);
    }

    #endregion
}
