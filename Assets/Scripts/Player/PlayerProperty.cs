using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 보유 자산 정보
/// 아이템 정보, 재산
/// </summary>
public class PlayerProperty : MonoBehaviour
{
    public Dictionary<EProperty, Property> properties = new Dictionary<EProperty, Property>();


    void Awake()
    {
        Initiailze();
    }


    public void Initiailze()
    {
        // TODO : 데이터 받아올 것
        properties.Add(EProperty.Gold,      new Property(0));
        properties.Add(EProperty.Jewelry,   new Property(0));
    }
}