using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

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

    /*public bool SetActiveLoadingUI(bool value)
    {
        if (_isTranslatedLoadScreen)
        {
            return false;
        }
        _isTranslatedLoadScreen = true;
        if (value)
        {
            _loadScreen.DOFade(1f, 1f).OnComplete(() =>
        {
            _isTranslatedLoadScreen = false;
        });
        }
        else
        {
            _loadScreen.DOFade(0, 1f).OnComplete(() =>
        {
            _isTranslatedLoadScreen = false;
        });
        }
        return true;
    }*/

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

    public async UniTask LoadNewSceneAsync(string _buildSceneName)
    {
        if (_isSceneLoading)
        {
            return;
        }
        _isSceneLoading = true;
        await SetActiveLoadingUI(true);
        await LoadSceneAsync(_buildSceneName);
        await SetActiveLoadingUI(false);
        _isSceneLoading = false;
    }
    public async UniTask LoadNewSceneAsync(int _buildSceneIndex)
    {
        if (_isSceneLoading)
        {
            return;
        }
        _isSceneLoading = true;
        await SetActiveLoadingUI(true);
        await LoadSceneAsync(_buildSceneIndex);
        await SetActiveLoadingUI(false);
        _isSceneLoading = false;
    }
    public async UniTask LoadNewSceneAsync()
    {
        if (_isSceneLoading)
        {
            return;
        }
        _isSceneLoading = true;
        await SetActiveLoadingUI(true);
        await LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        await SetActiveLoadingUI(false);
        _isSceneLoading = false;
    }

    private async UniTask LoadSceneAsync(int _buildSceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_buildSceneIndex);
        asyncLoad.allowSceneActivation = false;
        // Ожидание завершения загрузки и обновление прогресса
        while (!asyncLoad.isDone)
        {
            //или проверяем нажание
            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                asyncLoad.allowSceneActivation = true;
                _isNextSceneLoaded = true;
            }
            loadingBar.value = Mathf.Lerp(0, 1, asyncLoad.progress / 0.9f);
            await UniTask.Yield(); 
        }
        
        _isSceneActive = true;
    }
    private async UniTask LoadSceneAsync(string _buildSceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_buildSceneName);
        asyncLoad.allowSceneActivation = false;
        // Ожидание завершения загрузки и обновление прогресса
        while (!asyncLoad.isDone)
        {
            //или проверяем нажание
            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                asyncLoad.allowSceneActivation = true;
                _isNextSceneLoaded = true;
            }
            loadingBar.value = Mathf.Lerp(0, 1, asyncLoad.progress / 0.9f);
            await UniTask.Yield();
        }
        
        _isSceneActive = true;
    }

    /*private IEnumerator LoadSceneAsync(int _buildSceneIndex)
    {
        AsyncOperation _loadAsync = SceneManager.LoadSceneAsync(_buildSceneIndex);
        _loadAsync.allowSceneActivation = false;

        while (!_loadAsync.isDone)
        {
            if (_loadAsync.progress >= .9f && !_loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(1.2f);
                _loadAsync.allowSceneActivation = true;
            }

            yield return null;
        }
    }
    private IEnumerator LoadSceneAsync(string _buildSceneName)
    {
        AsyncOperation _loadAsync = SceneManager.LoadSceneAsync(_buildSceneName);
        _loadAsync.allowSceneActivation = false;

        while (!_loadAsync.isDone)
        {
            if (_loadAsync.progress >= .9f && !_loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(1.2f);
                _loadAsync.allowSceneActivation = true;
            }

            yield return null;
        }
    }*/

}