using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TurretStat
{
    public float ReloadTime;
    public float Damage;
    public float Range;
}

[CreateAssetMenu(menuName = "SO/Turret")]
public class TurretStatSO : ScriptableObject
{
    public TurretStat FireTurretStat;
    public TurretStat WindTurretStat;
    public TurretStat WaterTurretStat;
    public TurretStat LandTurretStat;

}
