using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using Zenject;

public class AddressableManager : MonoSingleton<AddressableManager>
{
    [SerializeField]
    private List<AssetReference> _ambientData;

    public List<AssetReference> AmbientData => _ambientData;

    void Start()
    {
        Addressables.InitializeAsync().Completed += AddressableManager_Completed;
    }

    private void AddressableManager_Completed(AsyncOperationHandle<IResourceLocator> obj)
    {
        //allow to download addressables from cloud
        //load main menu data
    }
}

