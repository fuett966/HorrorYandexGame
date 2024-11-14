using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Skin", menuName = "Skins/Skin" )]
public class SkinSO : ScriptableObject
{
    public SkinType skinType;
    public GameObject skinGM;
    public int id;
    public Sprite icon;
    public bool isBuied;

}
public enum SkinType
{
    Head,
    Body,
    Pants,
    Shoes,
    Sword,
    Minion,
    Dance
};
