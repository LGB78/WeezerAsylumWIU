using UnityEngine;

[CreateAssetMenu(fileName = "FoodItem", menuName = "Scriptable Objects/FoodItem")]
public class FoodItem : ScriptableObject
{
    public string foodName;
    public string foodDescription;

    public Sprite unplatedFoodSprite;    // Sprite shown when held with cursor
    public Sprite platedFoodSprite;  // Sprite shown on plate/cutting board

    public bool isEdible; // true if safe to eat
    public bool isCuttable; //true if can be cut on chopping board

    public Vector2 spawnOffset;
    public int sortingOrder = 69;
}
