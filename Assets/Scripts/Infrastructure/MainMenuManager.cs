using UnityEngine;
using UnityEngine.AddressableAssets;

public class MainMenuManager : MonoBehaviour
{

    [Header("Windows")]
    [SerializeField] private GameObject _skinsPanel;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _noValuePanel;
    [SerializeField] private GameObject _donatePanel;

    [Header("Skins windows")]
    [SerializeField] private GameObject _buyByValue;
    [SerializeField] private GameObject _buyByMoney;
    [SerializeField] private GameObject _buyByCrystal;
    [SerializeField] private GameObject _viewPartsContent;
    [SerializeField] private GameObject _viewSkinsContent;

    private void Awake()
    {
        
        
        
        _skinsPanel.SetActive(false);
        _noValuePanel.SetActive(false);
        _donatePanel.SetActive(false);
    }
    
    private void Start()
    { 
        MainAudioManager.instance.PlayMainSourceAudio(AddressableManager.instance.AmbientData[1].Asset as AudioClip);
    }
    
    public async void ChangeScene(int _levelID)
    {
        await LevelLoader.instance.LoadNewSceneAsync(_levelID);
    }
    
    public void OpenSkins(bool value)
    {
        _skinsPanel.SetActive(value);
        _mainPanel.SetActive(!value);
    }
}
