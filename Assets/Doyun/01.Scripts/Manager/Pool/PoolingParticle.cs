using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingParticle : PoolableMono
{
    private ParticleSystem _particleSystem;

    private WaitForSeconds _particleDuration;

    private bool _isPlay = false;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleDuration = new WaitForSeconds(_particleSystem.main.duration + 2f);
    }

    public void SetPositionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.SetPositionAndRotation(pos, rot);
    }

    public void Play()
    {
        if (_isPlay)
            return;
        
        StartCoroutine(PlayRoutine());
    }

    private IEnumerator PlayRoutine()
    {
        _particleSystem.Play();
        _isPlay = true;
        yield return _particleDuration;
        _isPlay = false;
        PoolManager.Instance.Push(this);
    }

    public override void Init()
    {
    }
}
