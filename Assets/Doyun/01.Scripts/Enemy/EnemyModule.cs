using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyModule : MonoBehaviour
{
    private Enemy _enemyCon;
    public Enemy EnemyCon => _enemyCon;

    public virtual void SetUp(Enemy enemy)
    {
        _enemyCon = enemy;
    }
    
    public abstract void AwakeModule();
    public abstract void UpdateModule();
    public abstract void FixedUpdateModule();
}
