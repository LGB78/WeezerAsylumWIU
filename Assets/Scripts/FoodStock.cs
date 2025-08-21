using UnityEngine;

[CreateAssetMenu(fileName = "FoodStock", menuName = "Scriptable Objects/FoodStock")]
public class FoodStock : ScriptableObject
{
    public int stock;
    public int price;
    public int buyamt;
}
