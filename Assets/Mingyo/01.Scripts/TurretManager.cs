using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField]
    private TurretStatSO _turretStatSO;

    public static TurretManager Instance;

    public int UpgradeCount = 0;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("TurretManager is Tween");
        }
        Instance = this;

        SetUp();
    }

    private void SetUp()
    {
        _turretStatSO.FireTurretStat.ReloadTime = 0.5f;
        _turretStatSO.FireTurretStat.Damage = 5f;
        _turretStatSO.FireTurretStat.Range = 5f;

        _turretStatSO.WindTurretStat.ReloadTime = 0.7f;
        _turretStatSO.WindTurretStat.Damage = 2f;
        _turretStatSO.WindTurretStat.Range = 5f;

        _turretStatSO.WaterTurretStat.ReloadTime = 0.7f;
        _turretStatSO.WaterTurretStat.Damage = 2f;
        _turretStatSO.WaterTurretStat.Range = 5f;

        _turretStatSO.LandTurretStat.ReloadTime = 0.7f;
        _turretStatSO.LandTurretStat.Damage = 2f;
        _turretStatSO.LandTurretStat.Range = 5f;

    }

    public void UpgradeTurret(ElementType elementType, int value)
    {
        UpgradeCount++;

        value *= UpgradeCount;

        switch (elementType)
        {
            case ElementType.Air:
                _turretStatSO.WindTurretStat.ReloadTime += value;
                _turretStatSO.WindTurretStat.Damage += value;
                break;
            case ElementType.Earth:
                _turretStatSO.LandTurretStat.ReloadTime += value;
                _turretStatSO.LandTurretStat.Damage += value;
                break;
            case ElementType.Fire:
                _turretStatSO.FireTurretStat.ReloadTime += value;
                _turretStatSO.FireTurretStat.Damage += value;
                break;
            case ElementType.Water:
                _turretStatSO.WaterTurretStat.ReloadTime += value;
                _turretStatSO.WaterTurretStat.Damage += value;
                break;
        }

    }

}
