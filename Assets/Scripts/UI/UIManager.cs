using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private BasePanel _titlePanel;

    [SerializeField]
    private BasePanel _optionPanel;

    [SerializeField]
    private BasePanel _gameplayPanel;

    [SerializeField]
    private Button _startButton;

    [SerializeField]
    private Button _optionButton;

    [SerializeField]
    private Button _closeOptionButton;

    [SerializeField]
    private Scrollbar _bgmScrollbar;

    [SerializeField]
    private Scrollbar _sfxScrollbar;

    public static UIManager Instance { get; private set; }
    public static bool HasInstance => Instance != null;

    public event Action WhenStartedGame;
    public event Action<float> WhenBGMChanged;
    public event Action<float> WhenSFXChanged;
    
    private bool _isInitialized;
    
    
    
    private void Start()
    {
        // for test
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
        _optionPanel.ClosePanel();
        _gameplayPanel.ClosePanel();

        _bgmScrollbar.onValueChanged.AddListener(OnBGMChanged);
        _sfxScrollbar.onValueChanged.AddListener(OnSFXChanged);

        _startButton.onClick.AddListener(OnStartGame);
        _optionButton.onClick.AddListener(_optionPanel.OpenPanel);
        _closeOptionButton.onClick.AddListener(_optionPanel.ClosePanel);
        
        _isInitialized = true;
    }

    public void OnBGMChanged(float value)
    {
        WhenBGMChanged?.Invoke(value);
        Debug.Log($"BGM : {value}");
    }

    public void OnSFXChanged(float value)
    {
        WhenSFXChanged?.Invoke(value);
        Debug.Log($"SFX : {value}");
    }

    private void OnStartGame()
    {
        WhenStartedGame?.Invoke();

        _titlePanel.ClosePanel();
        _optionPanel.ClosePanel();
        _gameplayPanel.OpenPanel();
        
        
    }
}