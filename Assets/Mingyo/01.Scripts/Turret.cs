using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    LayerMask _enemyLayer = 1 << 7;

    protected float detectionAngle = 60f;

    protected Animator _animator;

    protected int attackTriggerHash = Animator.StringToHash("AttackTrigger");

    protected abstract void OnShoot();

    protected abstract void SetUp();

    protected abstract void Attack();

    protected bool CheckInnerDistance(float range, Vector2 sectorDir)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, _enemyLayer);

        foreach(Collider2D collider in colliders)
        {
            Vector2 directiontoEnemy = collider.transform.position - transform.position;

            float angle = Vector2.Angle(sectorDir, directiontoEnemy);

            if(angle <= detectionAngle / 2)
            {
                return true;
            }
        }

        return false;
    }

    protected void DrawFanShapedGizmo(Vector3 origin, float range, float angle, Vector2 dir)
    {
        float halfAngle = angle / 2f;
        Vector3 forwardVector = Quaternion.Euler(0, 0, -halfAngle) * dir * range;

        Gizmos.DrawRay(origin, forwardVector);
        Gizmos.DrawRay(origin, Quaternion.Euler(0, 0, angle) * forwardVector);

        float fromAngle = -halfAngle;
        float toAngle = halfAngle * 2;

        for (int i = 0; i < 20; i++)
        {
            float lerpAmount = (float)i / 20f;
            float angleLerp = Mathf.Lerp(fromAngle, toAngle, lerpAmount);
            Vector3 rayDirection = Quaternion.Euler(0, 0, angleLerp) * forwardVector;

            Gizmos.DrawRay(origin, rayDirection);
        }
    }
}
