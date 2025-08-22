using UnityEngine;

[CreateAssetMenu(fileName = "FoodItem", menuName = "Scriptable Objects/FoodItem")]
public class FoodItem : ScriptableObject
{
    public string foodName;
    public string foodDescription;

    public Sprite unplatedFoodSprite;    // Sprite shown when held with cursor
    public Sprite platedFoodSprite;  // Sprite shown on plate/cutting board

    public bool onplate; //bool to determine whether when plated, it goes on plate or not

    public bool isCuttable; //true if can be cut on chopping board

    public Vector2 spawnOffset;
    public int sortingOrder = 69;

    public Vector2 stackOffset = new Vector2(0, 0.05f);
}
