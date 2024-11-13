using System;
using System.Collections;
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

    public PlayerData PlayerData { get; private set; }
    public event Action OnLoadComplete; 

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        // TODO : DB에 저장하기
        savePath = Application.persistentDataPath; // 테스트용 로컬 저장

        Inventory = GetComponent<Inventory>();
        Property = GetComponent<Property>();
        Equipment = GetComponent<Equipment>();
    }

    private void Start()
    {
        LoadPlayerData();
    }

    void LoadPlayerData()
    {
        if (handler != null)
        {
            StopCoroutine(handler);
            handler = null;
        }

        handler = StartCoroutine(LoadPlayerDataRoutine(ProcessLoadResult));
    }

    Coroutine handler;
    IEnumerator LoadPlayerDataRoutine(Action<bool> callback = null)
    {
        try
        {
            PlayerData = LoadData<PlayerData>();
            PlayerData.isFirst = false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            callback?.Invoke(false);
            yield break;
        }
        
        callback?.Invoke(true);
    }

    void ProcessLoadResult(bool isSuccess)
    {
        if (isSuccess)
        {
            // 게임 시작
            OnLoadComplete?.Invoke();
            SceneLoader.Instance.LoadMenuScene();
            //로드한 데이터 뿌려주기
        }
        else
        {   
            // 플레이어 정보 생성 절차
            UIRegister uiRegister = Resources.Load<UIRegister>(CustomData.Constants.PATH_UI_REGISTER);
            Instantiate(uiRegister, null);
        }
    }

    public void CreateNewPlayerData(string name)
    {
        PlayerData = new PlayerData();
        PlayerData.isFirst = true;
        PlayerData.playerName = name;

        PlayerData.level = 1;
        PlayerData.experience = 0f;
        
        PlayerData.gold = 1000;
        PlayerData.jewelry = 500;
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

