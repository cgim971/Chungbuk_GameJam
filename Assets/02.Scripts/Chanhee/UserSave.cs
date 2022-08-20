using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSave : MonoBehaviour
{

    SaveManager saveManager = null;

    //클리어한 스테이지. 1스테이지(튜토리얼)는0번임
    public static int OpenedStage = 0;
    
    //기본 홍룡포 제외 다른 스킨들 소유 여부. 0=빨강 1=노랑 2=파랑 3=군복 4=장복
    public static bool[] haveSkin=new bool[5] { true, false, false, false, false};

    //현재 적용중인 스킨 번호  0=빨강 1=노랑 2=파랑 3=군복 4=장복
    public static int currentSkin = 0; 

    [SerializeField] private int _money = 0;



    private int _initialMoney = 0;
    private readonly string _playerPrefsMoneyKey = "PlayerPrefsMoneyKey";
    public int Money
    {
        get => _money;
        set
        {
            _money = value;
            saveManager.SaveData(_playerPrefsMoneyKey, Money);
        }
    }

    [SerializeField] private List<bool> _getItems = new List<bool>();
    private readonly string _playerPrefsGetItemsKey = "PlayerPrefsGetItemsKey";
    public List<bool> GetItems
    {
        get => _getItems;
        set
        {
            _getItems = value;
            saveManager.SaveData(_playerPrefsGetItemsKey, GetItems);
        }
    }

    [SerializeField] private List<bool> _useItems = new List<bool>();
    private readonly string _playerPrefsUseItemsKey = "PlayerPrefsUseItemsKey";
    public List<bool> UseItems
    {
        get => _useItems;
        set
        {
            _useItems = value;
            saveManager.SaveData(_playerPrefsUseItemsKey, _useItems);
        }
    }

    [SerializeField] 

    public void LoadData()
    {
        saveManager = GameManager.Instance.saveManager;

        Money = saveManager.LoadIntData(_playerPrefsMoneyKey, _initialMoney);
        GetItems = saveManager.LoadListData(_playerPrefsGetItemsKey);
        UseItems = saveManager.LoadListData(_playerPrefsUseItemsKey);
    } 

    public void ResetData()
    {
        saveManager.DeleteData(_playerPrefsMoneyKey);
        saveManager.DeleteData(_playerPrefsGetItemsKey);
        saveManager.DeleteData(_playerPrefsUseItemsKey);
    }
}
