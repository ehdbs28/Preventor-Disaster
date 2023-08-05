using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TurretStat
{
    public Turret turret; 
    public float AttackSpeed;
    public float Damage;
    public float Range;
    public int Hp;
}

[CreateAssetMenu(menuName = "SO/Turret")]
public class TurretStatSO : ScriptableObject
{
    public List<TurretStat> TurretStatList;

}
