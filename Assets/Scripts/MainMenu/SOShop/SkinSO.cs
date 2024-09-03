using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "Skin", menuName = "Skins/Skin" )]
public class SkinSO : ScriptableObject
{
    public SkinType skinType;
    public GameObject skinGM;
    public int id;
    public Sprite icon;

}
public enum SkinType
{
    Head,
    Body,
    Pants,
    Shoes,
    Sword,
    Minion,
    Empty
};
