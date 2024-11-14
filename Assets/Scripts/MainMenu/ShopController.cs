using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private ShopCategory[] _categories;
    [SerializeField] private GameObject[] _categoriesButton;
    [SerializeField] private GameObject _categoriesContent;
    [SerializeField] private List<ShopButton> _shopButtons;
    private SkinType _currentSkinType;
    public ShopButton prefab;
    private ObjectPool<ShopButton> _shopButtonsPool;


    private void Start()
    {
        _shopButtonsPool = new ObjectPool<ShopButton>(prefab);
        ModifyContent(0);
    }

    public void ModifyContent(int id)
    {
        SkinType typeCategory;
        switch (id)
        {
            default:
            case 0:
                typeCategory = SkinType.Head;
                break;
            case 1:
                typeCategory = SkinType.Body;
                break;
            case 2:
                typeCategory = SkinType.Pants;
                break;
            case 3:
                typeCategory = SkinType.Shoes;
                break;
            case 4:
                typeCategory = SkinType.Sword;
                break;
            case 5:
                typeCategory = SkinType.Minion;
                break;
            case 6:
                typeCategory = SkinType.Dance;
                break;
        }


        if (_currentSkinType == typeCategory)
        {
            return;
        }

        _currentSkinType = typeCategory;
        foreach (ShopButton shopButton in _shopButtons)
        {
            _shopButtonsPool.ReturnObject(shopButton);
        }

        for (int i = 0; i < _categories.Length; i++)
        {
            if (_categories[i].SkinType == typeCategory)
            {
                SwitchCategory(_categories[i].content);
                break;
            }
        }
    }

    private void SwitchCategory(SkinSO[] skins)
    {
        for (int i = 0; i < skins.Length; i++)
        {
            SpawnButton(skins[i]);
        }
    }

    private void SpawnButton(SkinSO skin)
    {
        ShopButton button = _shopButtonsPool.GetObject();
        button.transform.parent = _categoriesContent.transform;
        _shopButtons.Add(button);
        button.ChangeContent(skin);
    }
}