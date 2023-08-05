using UnityEngine;

public class EnemyMovementModule : EnemyModule
{
    [SerializeField]
    private float _initSpeed;
    private float _speed;
    
    public override void AwakeModule()
    {
        _speed = _initSpeed * PhaseManager.Instance.CurPhase;

        switch (EnemyCon.ElementType)
        {
            case ElementType.Fire:
                EnemyCon.ActionData.Dir = Vector3.down;
                break;
            case ElementType.Water:
                EnemyCon.ActionData.Dir = Vector3.up;
                break;
            case ElementType.Air:
                EnemyCon.ActionData.Dir = Vector3.left;
                break;
            case ElementType.Earth:
                EnemyCon.ActionData.Dir = Vector3.right;
                break;
        }
    }

    public override void UpdateModule()
    {
        if (EnemyCon.ActionData.IsArrived)
            return;
        
        EnemyCon.transform.position += EnemyCon.ActionData.Dir * (_speed * Time.deltaTime);
    }

    public override void FixedUpdateModule()
    {
    }
}
