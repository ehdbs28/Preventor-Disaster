using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance = null;
    
    private Coroutine _runningRoutine = null;

    [SerializeField] 
    private float _spawnPosDistance;
    
    [SerializeField]
    private int _spawnMinCount = 3;

    [SerializeField] 
    private int _spawnMaxCount = 5;

    [SerializeField] 
    private List<Transform> _spawnPoints = new List<Transform>();

    private void Start()
    {
        PhaseManager.Instance.OnPhaseStartEvent += OnMonsterSpawn;
    }

    private void OnMonsterSpawn()
    {
        if (_runningRoutine != null)
        {
            StopCoroutine(_runningRoutine);
            _runningRoutine = null;
        }
        // 이거 수치 필요
        _runningRoutine = StartCoroutine(SpawnRoutine(new WaitForSeconds(3f)));
    }

    private IEnumerator SpawnRoutine(WaitForSeconds wfs)
    {
        while (PhaseManager.Instance.IsPhase)
        {
            ElementType elementType = (ElementType)Random.Range(0, 4);
            int count = Random.Range(_spawnMinCount, _spawnMaxCount) * PhaseManager.Instance.CurPhase / 2;
    
            for (int i = 0; i < count; i++)
            {
                EnemyType enemyType = (EnemyType)Random.Range(0, 3);
                Vector3 spawnPos = _spawnPoints[(int)elementType].position;
                Vector3 randomPos = spawnPos;
                
                // 세로 줄
                if (elementType == ElementType.Fire || elementType == ElementType.Water)
                {
                    float posX = Random.Range(spawnPos.x - _spawnPosDistance, spawnPos.x + _spawnPosDistance);
                    randomPos.x = posX;
                }
                // 가로 줄
                else
                {
                    float posY = Random.Range(spawnPos.y - _spawnPosDistance, spawnPos.y + _spawnPosDistance);
                    randomPos.y = posY;
                }

                Enemy enemy = PoolManager.Instance.Pop($"Enemy_{elementType}({enemyType})") as Enemy;
                if (enemy != null)
                {
                    enemy.transform.position = randomPos;

                    Vector3 dir = (Vector3.zero - spawnPos).normalized;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    enemy.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    enemy.GetModule<EnemyHealthModule>().OnDieEvent += () =>
                    {
                        // 이펙트 추가
                        GameManager.Instance.IsGameOver = true;
                    };
                }
            }
            yield return wfs;   
        }
    }
}
