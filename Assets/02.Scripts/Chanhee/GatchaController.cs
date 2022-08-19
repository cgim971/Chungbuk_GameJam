using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GatchaController : MonoBehaviour
{
    [SerializeField] private Button _btnUseShop = null;

    private void Awake()
    {
        if (_btnUseShop == null)
            _btnUseShop = transform.Find("ShopButton").GetComponent<Button>();
    }




}
