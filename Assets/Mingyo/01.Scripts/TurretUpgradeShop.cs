using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;

public class TurretUpgradeShop : MonoBehaviour
{
    [SerializeField]
    private Image _shopPannel;
    [SerializeField]
    bool isOn = false;
    [SerializeField]
    TextMeshProUGUI nomoneyText;

    private float textFadeTime = 1f;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            ShopPannelOnOff();
        }
    }
    public void ShopPannelOnOff()
    {
        if (isOn)
        {
            _shopPannel.gameObject.SetActive(false);
            Time.timeScale = 1;
            isOn = false;
        }
        else
        {
            _shopPannel.gameObject.SetActive(true);
            Time.timeScale = 0;
            isOn = true;
        }
    }

    public void UpgradeTurret(string name)
    {
        ElementType elementType = ElementType.Fire;

        switch (name)
        {
            case "Air":
                elementType = ElementType.Air;
                break;
            case "Fire":
                elementType = ElementType.Fire;
                break;
            case "Water":
                elementType = ElementType.Water;
                break;
            case "Earth":
                elementType = ElementType.Earth;
                break;
        }

        if (ItemManager.Instance.Payment(elementType, TurretManager.Instance.UpgradeCount * 2))
        {
            TurretManager.Instance.UpgradeTurret(elementType, TurretManager.Instance.UpgradeCount);
        }
        else
        {
            nomoneyText.DOKill();

            nomoneyText.DOFade(1f, textFadeTime).SetUpdate(true).OnComplete(() =>
            {
                nomoneyText.DOFade(0f, textFadeTime).SetUpdate(true);
            });
        }
    }
}
