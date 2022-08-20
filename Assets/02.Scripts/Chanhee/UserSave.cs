using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSave : MonoBehaviour
{

    SaveManager saveManager = null;

    //Ŭ������ ��������. 1��������(Ʃ�丮��)��0����
    public static int OpenedStage = 0;
    
    //�⺻ ȫ���� ���� �ٸ� ��Ų�� ���� ����. 0=���� 1=��� 2=�Ķ� 3=���� 4=�庹
    public static bool[] haveSkin=new bool[5] { true, false, false, false, false};

    //���� �������� ��Ų ��ȣ  0=���� 1=��� 2=�Ķ� 3=���� 4=�庹
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
