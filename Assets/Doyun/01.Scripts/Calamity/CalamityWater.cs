using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CalamityWater : Calamity
{
    [SerializeField]
    private Transform _spawnMin, _spawnMax;

    [SerializeField] 
    private float _attackDelay;
    
    public override void Init()
    {
    }

    public override void OnCalamity()
    {
        StartCoroutine(CalamityRoutine());
    }

    private IEnumerator CalamityRoutine()
    {
        float count = Random.Range(1f, 2f);

        for (int i = 0; i < count; i++)
        {
            float point = Random.Range(_spawnMin.position.x, _spawnMax.position.x);
            Vector3 spawnPos = new Vector3(point, _spawnMax.position.y);

            for (float y = spawnPos.y; y <= spawnPos.y + 25f; y += 0.5f)
            {
                Vector3 pos = spawnPos;
                pos.y = y;
                
                PoolingParticle particle = PoolManager.Instance.Pop("WaterParticle") as PoolingParticle;
                particle.SetPositionAndRotation(pos, Quaternion.identity);
                particle.Play();

                Collider[] cols = Physics.OverlapBox(pos, Vector3.one, Quaternion.identity, _targetLayer);
                for (int j = 0; j < cols.Length; j++)
                {
                    if (cols[j].TryGetComponent<IDamageable>(out var onDamage))
                    {
                        onDamage.OnDamage(_damage);
                    }
                }

                yield return new WaitForSeconds(0.01f);
            }
            
            yield return new WaitForSeconds(_attackDelay);
        }
    }
}
