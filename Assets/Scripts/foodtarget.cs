using UnityEngine;

public class FoodTarget : MonoBehaviour
{
    public Transform foodContainer;
    public bool isBoard;

    void Awake()
    {
        if (foodContainer == null)
            foodContainer = transform;
    }

    public void ReceiveFood(FoodItem food, GameObject foodreference)
    {
        if (food == null) return;

        GameObject newFood = new GameObject(food.foodName);
        newFood.transform.SetParent(foodContainer);
        newFood.AddComponent<Collider2D>();

        // Apply offset from FoodItem
        Vector3 pos = transform.position;
        pos.x += food.spawnOffset.x;
        pos.y += food.spawnOffset.y;
        newFood.transform.position = pos;

        SpriteRenderer sr = newFood.AddComponent<SpriteRenderer>();
        sr.sprite = food.platedFoodSprite;
        sr.sortingOrder = food.sortingOrder;
    }
}
