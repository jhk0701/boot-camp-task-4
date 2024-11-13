using System;
using System.Collections.Generic;
using UnityEngine;

public enum EProperty
{
    Gold, // 기본 화폐
    Jewelry, // 재화 유형 1 : 강화 재료
}

/// <summary>
/// 플레이어의 보유 자산 정보
/// 아이템 정보, 재산
/// </summary>
public class Property : MonoBehaviour
{
    public Dictionary<EProperty, PositiveValue> properties = new Dictionary<EProperty, PositiveValue>();


    void Awake()
    {
        Initiailze();
    }

    public void Initiailze()
    {
        // TODO : 데이터 받아올 것
        properties.Add(EProperty.Gold,      new PositiveValue(0));
        properties.Add(EProperty.Jewelry,   new PositiveValue(0));
    }

    public void Earn(EProperty type, ulong amount)
    {
        properties[type].Add(amount);
    }
    
    public bool Pay(EProperty type, ulong amount)
    {
        if (properties[type].Value < amount) 
            return false;
        
        properties[type].Subtract(amount);
        return true;
    }
}