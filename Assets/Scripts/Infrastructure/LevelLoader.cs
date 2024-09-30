using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

public class LevelLoader : MonoSingleton<LevelLoader>
{

    [Header("Loading UI")]
    [SerializeField] private Slider loadingBar;
    [SerializeField] private GameObject _loadScreenGM;
    [SerializeField] private Image _loadScreen;

    private bool _isTranslatedLoadScreen = false;
    private bool _isSceneLoading = false;
    private bool _isNextSceneLoaded = false;
    private bool _isSceneActive = false;
    public bool isTranslatedLoadScreen => _isTranslatedLoadScreen;
    public bool IsSceneLoading => _isSceneLoading;
    public bool IsNextSceneLoaded => _isNextSceneLoaded;
    public bool IsSceneActive => _isSceneActive;

    private async UniTask SetActiveLoadingUI(bool value)
    {
        if (_isTranslatedLoadScreen)
        {
            return;
        }
        _isTranslatedLoadScreen = true;

        if (value)
        {
            _loadScreen.gameObject.SetActive(true);
            await _loadScreen.DOFade(1f, 1f).OnComplete(() =>
             {
                 _isTranslatedLoadScreen = false;
                 loadingBar.gameObject.SetActive(true);
             }).AsyncWaitForCompletion();
        }
        else
        {
            loadingBar.gameObject.SetActive(false);
            await _loadScreen.DOFade(0, 1f).OnComplete(() =>
            {
                _isTranslatedLoadScreen = false;
                _loadScreen.gameObject.SetActive(false);

            }).AsyncWaitForCompletion();
        }

    }

    public void FastSetActiveLoadingUI(bool value)
    {
        if (value)
        {
            _loadScreen.DOFade(1, 0);
        }
        else
        {
            _loadScreen.DOFade(0, 0);
        }

    }

    public async UniTask LoadNewSceneAsync(string newBuildSceneName)
    {
        await LoadProcess(SceneManager.GetSceneByName(newBuildSceneName).buildIndex);
    }
    
    public async UniTask LoadNewSceneAsync(int newBuildSceneIndex)
    {
        await LoadProcess(newBuildSceneIndex);
    }
    
    public async UniTask LoadNewSceneAsync()
    {
        await LoadProcess(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private async UniTask LoadProcess(int buildIndex)
    {
        if (_isSceneLoading)
        {
            return;
        }
        _isSceneLoading = true;
        await SetActiveLoadingUI(true);
        MainAudioManager.instance.PauseMainSourceAudio();
        //await LoadAmbientAsync(AddressableManager.instance.AmbientData[buildIndex]);
        await LoadSceneAsync(buildIndex);
        await SetActiveLoadingUI(false);
        _isSceneLoading = false;
    }

    private async UniTask LoadAmbientAsync(AssetReference reference)
    {
        var operation = reference.LoadAssetAsync<AudioClip>();
        while (!operation.IsDone)
        {
            loadingBar.value = Mathf.Lerp(0, 0.5f, operation.PercentComplete / 0.9f);
            await UniTask.Yield(); 
        }  
    }
    
    private async UniTask LoadSceneAsync(int _buildSceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_buildSceneIndex);
        asyncLoad.allowSceneActivation = false; 
        while (!asyncLoad.isDone)
        { 
            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                asyncLoad.allowSceneActivation = true;
                _isNextSceneLoaded = true;
            }
            loadingBar.value = Mathf.Lerp(0.5f, 1, asyncLoad.progress / 0.9f);
            await UniTask.Yield(); 
        }
        
        _isSceneActive = true;
    }
}