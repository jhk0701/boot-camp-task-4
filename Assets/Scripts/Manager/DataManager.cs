using UnityEngine;
using System.IO;

[RequireComponent(typeof(Property))]
[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(Equipment))]
public class DataManager : Singleton<DataManager>
{
    string savePath;

    public Inventory Inventory { get; private set; }
    public Property Property { get; private set; }
    public Equipment Equipment { get; private set; }


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // TODO : DB에 저장하기
        savePath = Application.streamingAssetsPath; // 테스트용 로컬 저장

        Inventory = GetComponent<Inventory>();
        Property = GetComponent<Property>();
        Equipment = GetComponent<Equipment>();
    }

    public void SaveData<T>(T data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath + $"/{typeof(T).ToString()}.txt", json);
    }

    public T LoadData<T>()
    {
        string file = File.ReadAllText(savePath + $"/{typeof(T).ToString()}.txt");
        return JsonUtility.FromJson<T>(file);
    }
}

