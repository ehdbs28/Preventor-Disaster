using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField]
    private TurretStatSO _turretStatSO;

    public static TurretManager Instance;

    private int mainUpgradeCount = 0;
    private int subUpgradeCount = 0;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("TurretManager is Tween");
        }
        Instance = this;

        SetUp();

        for(int i = 0; i < 2; i++)
        {
            MainTurretUpgrade("AttackSpeed", 10);
            SubTurretUpgrade("AttackSpeed", 10);
        }
    }

    private void SetUp()
    {
        _turretStatSO.MainTurretStat.AttackSpeed = 0.5f;
        _turretStatSO.MainTurretStat.Damage = 5f;
        _turretStatSO.MainTurretStat.Range = 5f;
        _turretStatSO.MainTurretStat.Hp = 50;

        _turretStatSO.SubTurretStat.AttackSpeed = 0.7f;
        _turretStatSO.SubTurretStat.Damage = 2f;
        _turretStatSO.SubTurretStat.Range = 5f;
        _turretStatSO.SubTurretStat.Hp = 50;
    }

    public void MainTurretUpgrade(string stat, int value)
    {
        mainUpgradeCount++;

        value *= mainUpgradeCount;

        switch (stat)
        {
            case "AttackSpeed":
                _turretStatSO.MainTurretStat.AttackSpeed += value;
                break;
            case "Damage":
                _turretStatSO.MainTurretStat.Damage += value;
                break;
            case "Range":
                _turretStatSO.MainTurretStat.Range += value;
                break;
            case "Hp":
                Debug.Log(stat);
                _turretStatSO.MainTurretStat.Hp += value;
                break;
        }

    }

    public void SubTurretUpgrade(string stat, int value)
    {
        subUpgradeCount++;

        value *= subUpgradeCount;

        switch (stat)
        {
            case "AttackSpeed":
                _turretStatSO.SubTurretStat.AttackSpeed += value;
                break;
            case "Damage":
                _turretStatSO.SubTurretStat.Damage += value;
                break;
            case "Range":
                _turretStatSO.SubTurretStat.Range += value;
                break;
            case "Hp":
                _turretStatSO.SubTurretStat.Hp += value;
                break;
        }

    }
}
