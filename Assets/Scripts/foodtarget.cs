using UnityEngine;

public class FoodTarget : MonoBehaviour
{
    public Transform foodContainer; // optional parent for spawned food sprites
    public float SpawnY = 0.28f;
    public float SpawnX = 0f;

    void Awake()
    {
        // if no container is set, just use this object
        if (foodContainer == null)
            foodContainer = transform;
    }

    public void ReceiveFood(FoodItem food)
    {
        if (food != null)
        {
            // Spawn a new GameObject for this food
            GameObject newFood = new GameObject(food.foodName);
            newFood.transform.SetParent(foodContainer);

            // Position it above the plate (y+1 for now)
            Vector3 pos = transform.position;
            pos.y += SpawnY;
            pos.x += SpawnX;
            newFood.transform.position = pos;

            // Add sprite renderer
            SpriteRenderer sr = newFood.AddComponent<SpriteRenderer>();
            sr.sprite = food.platedFoodSprite;
            sr.sortingOrder = 69; // make sure it’s above the plate

            //Debug.Log($"{food.foodName} added on {gameObject.name}");
        }
    }
}
