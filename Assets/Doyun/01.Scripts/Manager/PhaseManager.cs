using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public static PhaseManager Instance = null;
    
    private int _curPhase;
    public int CurPhase => _curPhase;

    [SerializeField]
    private float _maxPhaseTime, _minPhaseTime;

    [SerializeField] 
    private float _maxPhaseDelay, _minPhaseDelay;
    
    private float _phaseTime;
    private float _phaseDelay;

    private WaitForSeconds _phaseTimeWFS;
    private WaitForSeconds _phaseDelayWFS;

    private bool _isPhase = false;
    public bool IsPhase => _isPhase;

    public event Action OnPhaseStartEvent = null;

    private void Start()
    {
        _curPhase = 0;
        SetPhaseTime(_maxPhaseTime);
        SetPhaseDelay(_maxPhaseDelay);

        StartCoroutine(PhaseRoutine());
    }

    private IEnumerator PhaseRoutine()
    {
        while (!GameManager.Instance.IsGameOver)
        {
            yield return _phaseDelayWFS;
            ++_curPhase;
            _isPhase = true;
            OnPhaseStartEvent?.Invoke();
            
            MainSceneUIManager.Instance.SetPhase(true);
            
            yield return _phaseTimeWFS;
            
            MainSceneUIManager.Instance.SetPhase(false);
            
            _isPhase = false;
        }
    }

    private void SetPhaseTime(float t)
    {
        _phaseTime = t;
        _phaseTime = Mathf.Clamp(_phaseTime, _minPhaseTime, _maxPhaseTime);
        _phaseTimeWFS = new WaitForSeconds(_phaseTime);
    }

    private void SetPhaseDelay(float t)
    {
        _phaseDelay = t;
        _phaseDelay = Mathf.Clamp(_phaseDelay, _minPhaseDelay, _maxPhaseDelay);
        _phaseDelayWFS = new WaitForSeconds(_phaseDelay);
    }
}
