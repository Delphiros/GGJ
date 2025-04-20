using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private BasePanel _titlePanel;

    [SerializeField]
    private Button _startButton;

    public static UIManager Instance { get; private set; }
    public static bool HasInstance => Instance != null;

    public event Action WhenStartedGame;
    private bool _isInitialized;
    
    
    private void Start()
    {
        Init();
    }

    public void Init()
    {
        if (_isInitialized)
        {
            Debug.LogAssertion("UIManager is already initialized.");
            return;
        }

        Instance = this;
        _titlePanel.OpenPanel();
    }
}