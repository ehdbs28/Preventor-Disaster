using System;
using UnityEngine;

public class CalamityEarth : Calamity
{
    [SerializeField] 
    private Transform _pos;
    
    public override void Init()
    {
    }

    public override void OnCalamity()
    {
        PoolingParticle particle = PoolManager.Instance.Pop("EarthParticle") as PoolingParticle;
        particle.SetPositionAndRotation(_pos.position, Quaternion.identity);
        particle.Play();
        
        CameraManager.Instance.ShakeCam(10f, 0.1f);
    }
}
