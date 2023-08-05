using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    
    private int[] _items = new int[4];

    public bool Payment(ElementType type, int pay)
    {
        if (_items[(int)type] - pay < 0)
            return false;

        _items[(int)type] -= pay;
        return true;
    }

    public void AddItem(ElementType type)
    {
        _items[(int)type] += Random.Range(3, 7);
    }
}
