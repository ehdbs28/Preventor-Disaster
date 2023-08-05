using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTurret : Turret
{
    [SerializeField] TurretStatSO _turretStatSO;

    [SerializeField] Vector2 dir;

    [SerializeField] GameObject _bullet;                                      //Pool

    [SerializeField] ElementType type;

    protected override void Attack()
    {
        _animator.SetTrigger(attackTriggerHash);
    }

    private void Update()
    {
        if (CheckInnerDistance(_turretStatSO.FireTurretStat.Range, dir))
        {
            Attack();
        }
    }

    private void OnDrawGizmos()
    {
        DrawFanShapedGizmo(transform.position, _turretStatSO.FireTurretStat.Range, detectionAngle / 2, dir);
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

        StartCoroutine(ShootBullet());
    }

    private IEnumerator ShootBullet()
    {
        GameObject obj = Instantiate(_bullet, transform.position, Quaternion.identity);
        Bullet bullet = obj.GetComponent<Bullet>();

        float returnTime = 0;
        switch (type)
        {
            case ElementType.Fire:
                bullet.Damage = _turretStatSO.FireTurretStat.Damage;
                returnTime = _turretStatSO.FireTurretStat.ReloadTime;
                break;
            case ElementType.Earth:
                bullet.Damage = _turretStatSO.LandTurretStat.Damage;
                returnTime = _turretStatSO.LandTurretStat.ReloadTime;
                break;
            case ElementType.Air:
                bullet.Damage = _turretStatSO.WindTurretStat.Damage;
                returnTime = _turretStatSO.WindTurretStat.ReloadTime;
                break;
            case ElementType.Water:
                bullet.Damage = _turretStatSO.WaterTurretStat.Damage;
                returnTime = _turretStatSO.WaterTurretStat.ReloadTime;
                break;
        }

        yield return new WaitForSeconds(returnTime);
    }
}
