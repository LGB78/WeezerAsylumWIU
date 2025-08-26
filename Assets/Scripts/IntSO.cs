using UnityEngine;

[CreateAssetMenu(fileName = "IntSO", menuName = "Scriptable Objects/IntSO")]
public class IntSO : ScriptableObject
{
    public int value;

    public void IncreaseValue(int val)
    {
        value += val;
    }
}
