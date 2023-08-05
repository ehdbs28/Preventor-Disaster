using System.Threading;
using UnityEngine;

public class EnemyActionData : MonoBehaviour
{
    public Vector3 Dir = Vector3.zero;
    
    public bool IsArrived = false;

    public void Reset()
    {
        Dir = Vector3.zero;
        IsArrived = false;
    }
}
