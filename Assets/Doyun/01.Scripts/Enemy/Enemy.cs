using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : PoolableMono
{
    [SerializeField]
    private ElementType _elementType;
    public ElementType ElementType => _elementType;

    [SerializeField]
    private EnemyType _enemyType;
    public EnemyType EnemyType => _enemyType;

    private EnemyActionData _actionData;
    public EnemyActionData ActionData => _actionData;
    
    private List<EnemyModule> _modules;

    public bool IsAlive { get; set; }

    private void Awake()
    {
        _actionData = GetComponent<EnemyActionData>();
        
        Transform moduleTrm = transform.Find("Modules");
        _modules = new List<EnemyModule>();
        moduleTrm.GetComponentsInChildren<EnemyModule>(_modules);
    }

    private void Update()
    {
        if (!IsAlive)
            return;
        
        foreach (EnemyModule module in _modules)
        {
            module.UpdateModule();
        }
    }

    private void FixedUpdate()
    {
        if (!IsAlive)
            return;
        
        foreach (EnemyModule module in _modules)
        {
            module.FixedUpdateModule();
        }
    }

    public T GetModule<T>() where T : EnemyModule
    {
        T value = null;

        foreach (T module in _modules.OfType<T>())
        {
            value = module;
        }

        return value;
    }
    
    public override void Init()
    {
        _actionData.Reset();
        
        foreach (EnemyModule module in _modules)
        {
            module.SetUp(this);
            module.AwakeModule();
        }

        IsAlive = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_actionData.IsArrived && other.CompareTag("CalamityZone"))
        {
            _actionData.IsArrived = true;
        }
    }
}
