using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CheckCalamityCall : MonoBehaviour
{
    [SerializeField]
    private LayerMask _targetLayer;

    [SerializeField]
    private int _targetCheckLimit;
    
    private Calamity _calamity;
    private BoxCollider2D _collider;

    private const int FrameCount = 30;
    private int _frame;

    private bool _isCalamity = false;
    
    private void Awake()
    {
        _calamity = GetComponent<Calamity>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        _frame += 1;

        if (_frame >= FrameCount)
        {
            if (!_isCalamity && Check())
            {
                StartCoroutine(CalamityRoutine());
            }
            _frame = 0;
        }
    }

    private IEnumerator CalamityRoutine()
    {
        _isCalamity = true;
        _calamity.OnCalamity();
        yield return new WaitForSeconds(10f);
        _isCalamity = false;
    }

    private bool Check()
    {
        Collider[] cols = Physics.OverlapBox(_collider.offset, _collider.size / 2, Quaternion.identity, _targetLayer);
        return cols.Length >= _targetCheckLimit;
    }
}
