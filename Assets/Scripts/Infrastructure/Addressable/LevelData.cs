using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/Level")]
public class LevelData: ScriptableObject
{
    [SerializeField] private List<AssetReference> _assetReferences;
}
