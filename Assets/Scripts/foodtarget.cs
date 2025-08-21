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

        if (transform.childCount > 0 && gameObject.tag == "board") return;

        // Count how many of the same food type already exist
        int sameFoodCount = 0;
        foreach (Transform child in foodContainer)
        {
            if (child.name == food.foodName)
                sameFoodCount++;
        }

        // Spawn new instance
        GameObject newFood = new GameObject(food.foodName);
        newFood.transform.SetParent(foodContainer);


        var selfcollider = newFood.AddComponent<BoxCollider2D>();
        selfcollider.isTrigger = true;
        var parentscript = foodreference.GetComponent<TestFood>();
        var selfscript = newFood.AddComponent<TestFood>();
        selfscript.food = parentscript.food;
        selfscript.foodCut = parentscript.foodCut;

        // Apply offset from FoodItem + stacking offset per duplicate
        Vector3 pos = transform.position;
        pos.x += food.spawnOffset.x + (sameFoodCount * food.stackOffset.x);
        pos.y += food.spawnOffset.y + (sameFoodCount * food.stackOffset.y);
        newFood.transform.position = pos;

        // Add sprite renderer
        SpriteRenderer sr = newFood.AddComponent<SpriteRenderer>();
        sr.sprite = food.platedFoodSprite;

        //hihi lucas here the collider size here i decided to set to the sprite size
        selfcollider.size = selfcollider.gameObject.GetComponent<SpriteRenderer>().size;
        selfscript.isKnifeHeld = parentscript.isKnifeHeld;//same with this where i set the knife held stuff
        // Sorting order increases with each duplicate
        sr.sortingOrder = food.sortingOrder + sameFoodCount;
        //and then here we update the bounds of the testfood
        selfscript.getbounds();
        selfscript.activeFood = selfscript.food;//set the active food too
    }
}
