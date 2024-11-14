using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using CustomData;

[RequireComponent(typeof(Level))]
[RequireComponent(typeof(Ability))]
[RequireComponent(typeof(Property))]
[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(Equipment))]
public class DataManager : Singleton<DataManager>
{
    string savePath;

    public Level Level { get; private set; }
    public Ability Ability { get; private set; }
    public Status Status { get; private set; }
    public Property Property { get; private set; }
    public Inventory Inventory { get; private set; }
    public Equipment Equipment { get; private set; }

    public bool IsFirstAccess { get; private set; }
    public PlayerData PlayerData { get; private set; }
    public PlayerInventory PlayerInventory { get; private set; }
    
    public event Action OnLoadComplete;
    public event Action OnSave;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        // TODO : DB에 저장하기
        savePath = Application.persistentDataPath; // 테스트용 로컬 저장
        
        Level = GetComponent<Level>();
        Ability = GetComponent<Ability>();
        Status = GetComponent<Status>();
        Property = GetComponent<Property>();
        
        Inventory = GetComponent<Inventory>();
        Equipment = GetComponent<Equipment>();
    }

    private void Start()
    {
        LoadData();
        SceneLoader.Instance.OnLoadScene += (name) => { SaveData(); };
    }

    void LoadData()
    {
        StartCoroutine(LoadDataRoutine(ProcessLoadResult));
    }

    IEnumerator LoadDataRoutine(Action<bool> callback = null)
    {
        // TODO : 더 좋은 방법 찾아볼 것
        // 매니저들이 서로 간의 이벤트 구독을 마친 시점
        yield return null;
        
        try
        {
            PlayerData = LoadData<PlayerData>();
            PlayerInventory = LoadData<PlayerInventory>();
        }
        catch (Exception e)
        {
            // Debug.LogError(e.Message);
            callback?.Invoke(false);
            yield break;
        }
        
        callback?.Invoke(true);
    }

    void ProcessLoadResult(bool isSuccess)
    {
        IsFirstAccess = !isSuccess;
        if (isSuccess)
        {
            OnLoadComplete?.Invoke();
            // 게임 시작
            SceneLoader.Instance.LoadMenuScene();
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
        PlayerData.playerName = name;

        PlayerData.level = 1;
        PlayerData.experience = 0f;

        PlayerData.status = new List<JsonDictionary<EStatus, RangedStat>>();
        PlayerData.ability = new List<JsonDictionary<EAbility, PassiveStat>>();
        PlayerData.property = new List<JsonDictionary<EProperty, PositiveValue>>();

        PlayerInventory = new PlayerInventory();
        PlayerInventory.inventory = new Item[CustomData.Constants.INVENTORY_MAX_SIZE];
        PlayerInventory.equipment = new List<JsonDictionary<EEquipment, Item>>();
        
        OnLoadComplete?.Invoke();

        SaveData();
    }

    [ContextMenu("Save")]
    public void SaveData()
    {
        if (saveRoutineHandler != null)
        {
            StopCoroutine(saveRoutineHandler);
        }
        
        saveRoutineHandler = StartCoroutine(SaveDataRoutine());
    }
    
    Coroutine saveRoutineHandler;
    IEnumerator SaveDataRoutine()
    {
        OnSave?.Invoke();
        
        yield return null;
        
        SaveData(PlayerData);
        SaveData(PlayerInventory);

        saveRoutineHandler = null;
    }
    
    public void SaveData<T>(T data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath + $"/{typeof(T).ToString()}.txt", json);
    }

    public T LoadData<T>()
    {
        string file = File.ReadAllText(savePath + $"/{typeof(T).ToString()}.txt");
        return JsonUtility.FromJson<T>(file);
    }
}

