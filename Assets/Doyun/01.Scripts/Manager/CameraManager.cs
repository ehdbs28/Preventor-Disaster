using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    
    [SerializeField]
    private CinemachineVirtualCamera _playerVCam;
    private CinemachineBasicMultiChannelPerlin _playerVCamPerlin;

    private CinemachineVirtualCamera _activeVCam;
    private CinemachineBasicMultiChannelPerlin _activePerlin;

    private const int FrontPriority = 20;
    private const int BackPriority = 10;

    private Coroutine _runningRoutine = null;

    private void Awake()
    {
        _playerVCamPerlin = _playerVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void SetPlayerVCam()
    {
        if (_activeVCam != null)
        {
            _activeVCam.Priority = BackPriority;
        }
        
        _activeVCam = _playerVCam;
        _activePerlin = _playerVCamPerlin;

        _activeVCam.Priority = FrontPriority;
    }

    public void ShakeCam(float intensity, float duration)
    {
        if (_activeVCam == null || _activePerlin == null)
            return;

        if (_runningRoutine != null)
        {
            StopCoroutine(_runningRoutine);
            _runningRoutine = null;
        }

        _runningRoutine = StartCoroutine(ShakeRoutine(intensity, duration));
    }

    private IEnumerator ShakeRoutine(float intensity, float duration)
    {
        _activePerlin.m_AmplitudeGain = intensity;
        yield return new WaitForSeconds(duration);
        _activePerlin.m_AmplitudeGain = 0;
        _runningRoutine = null;
    }
}
