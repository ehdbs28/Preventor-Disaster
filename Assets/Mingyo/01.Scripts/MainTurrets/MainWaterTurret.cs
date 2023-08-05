using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWaterTurret : Turret
{
    [SerializeField] TurretStatSO _turretStatSO;

    protected override void Attack()
    {
        Debug.Log("321");
    }

    private void Update()
    {
        if (CheckInnerDistance(_turretStatSO.MainTurretStat.Range, Vector2.right))
        {
            Attack();
        }
    }

    private void OnDrawGizmos()
    {
        DrawFanShapedGizmo(transform.position, _turretStatSO.MainTurretStat.Range, detectionAngle / 2, Vector2.right);

    }
}
