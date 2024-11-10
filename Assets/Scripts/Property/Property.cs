using System;

public enum EProperty
{
    Gold, // 기본 화폐
    Jewelry, // 재화 유형 1 : 강화 재료
}

public class Property
{
    // 재화들은 음수를 가질 수 없으므로 ulong으로 선언
    ulong _value = 0;
    public ulong Value 
    {
        get => _value;
        private set
        {
            _value = value;
            onValueChange?.Invoke(Value);
        }
    }
    public event Action<ulong> onValueChange;


    public Property(ulong value)
    {
        Value = value;
    }


    public void Add(ulong amount)
    {
        Value += amount;
    }

    public void Subtract(ulong amount)
    {
        Value -= amount;
    }
}