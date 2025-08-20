
using UnityEngine;

[CreateAssetMenu(fileName = "foodorder", menuName = "Scriptable Objects/foodorder")]
public class foodorder : ScriptableObject
{
    public System.Collections.Generic.List<FoodItem> order = new System.Collections.Generic.List<FoodItem> ();
}
