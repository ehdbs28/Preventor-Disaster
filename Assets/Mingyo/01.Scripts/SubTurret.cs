using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTurret : Turret
{
    [SerializeField] TurretStatSO _turretStatSO;

    [SerializeField] Vector2 dir;

    [SerializeField] GameObject _bullet;                                      //Pool

    protected override void Attack()
    {
        _animator.SetTrigger(attackTriggerHash);
    }

    private void Update()
    {
        if (CheckInnerDistance(_turretStatSO.SubTurretStat.Range, dir))
        {
            Attack();
        }
    }

    private void OnDrawGizmos()
    {
        DrawFanShapedGizmo(transform.position, _turretStatSO.SubTurretStat.Range, detectionAngle / 2, dir);
    }

    protected override void SetUp()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        SetUp();
    }

    protected override void OnShoot()
    {
        Debug.Log("Shoot");

        Instantiate(_bullet, transform.position, Quaternion.identity);
    }
}
