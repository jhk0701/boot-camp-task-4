using System;

public class PositiveValue // 양의 수
{
    // 재화들은 음수를 가질 수 없으므로 ulong으로 선언
    ulong _value = 0;
    public ulong Value 
    {
        get => _value;
        private set
        {
            _value = value;
            OnValueChange?.Invoke(Value);
        }
    }
    public event Action<ulong> OnValueChange;


    public PositiveValue(ulong value)
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