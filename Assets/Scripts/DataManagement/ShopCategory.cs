using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor.Animations;

[CreateAssetMenu(fileName = "ShopCategory", menuName = "ShopCategory", order = 1)]
public class ShopCategory : ScriptableObject
{
    [Serializable]
    public class ShopItemDTO 
    {
        public string id;
        public AnimatorController animationClip;
    }

    public List<ShopItemDTO> items;

}
