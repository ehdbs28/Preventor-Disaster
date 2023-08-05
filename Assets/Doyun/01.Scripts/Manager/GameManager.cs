using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField]
    private PoolingListSO _poolingList;

    [SerializeField]
    private Transform _poolParent;

    public bool IsGameOver { get; set; }
    
    [field:SerializeField]
    public UnityEvent GameOverEvent;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple Singleton is Running (GameManager)");
        }

        Instance = this;
        
        AddManager();
    }

    private void Update()
    {
        if (IsGameOver)
        {
            GameOverEvent?.Invoke();
        }
    }

    private void AddManager()
    {
        PhaseManager.Instance = GetComponent<PhaseManager>();
        EnemyManager.Instance = GetComponent<EnemyManager>();
        CameraManager.Instance = GetComponent<CameraManager>();
        ItemManager.Instance = GetComponent<ItemManager>();
        PoolManager.Instance = new PoolManager(_poolParent);
        foreach (var pair in _poolingList.Pairs)
        {
            PoolManager.Instance.CreatePool(pair.Prefab, pair.Count);
        }
    }
}
