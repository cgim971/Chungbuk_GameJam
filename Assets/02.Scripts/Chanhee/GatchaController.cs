using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GatchaController : MonoBehaviour
{
    [SerializeField] private Button _btnUseShop = null;
    [SerializeField] private int _cost = 100;

    private void Awake()
    {
        if (_btnUseShop == null)
            _btnUseShop = transform.Find("ShopButton").GetComponent<Button>();
    }

    private void Start()
    {
        _btnUseShop.onClick.AddListener(() => UseShop());
    }


    public void UseShop()
    {

        if (GameManager.Instance.userSave.Money < _cost) return;

        GameManager.Instance.userSave.Money -= _cost;
        GetItem();
    }

    public void GetItem()
    {

    }


}
