using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLandTurret : Turret
{
    [SerializeField] TurretStatSO _turretStatSO;

    protected override void Attack()
    {
        Debug.Log("321");
    }

    private void Update()
    {
        if (CheckInnerDistance(_turretStatSO.TurretStatList[3].Range, Vector2.down))
        {
            Attack();
        }
    }

    private void OnDrawGizmos()
    {
        DrawFanShapedGizmo(transform.position, _turretStatSO.TurretStatList[3].Range, detectionAngle / 2, Vector2.down);
    }
}
