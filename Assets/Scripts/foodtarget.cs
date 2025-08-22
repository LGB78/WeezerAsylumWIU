using System.Collections.Generic;
using UnityEngine;

public class FoodTarget : MonoBehaviour
{
    public Transform foodContainer;
    public bool isBoard;
    public float newhigh = -999;
    int foodcount = 0;

    void Awake()
    {
        if (foodContainer == null)
            foodContainer = transform;
        foodcount = 0;
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
        foodcount++;
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


        if (food.onplate == true)
        {
            if (newhigh != -999)
            {
                pos.y = newhigh + food.stackOffset.y;
            }
            newhigh = pos.y;
        }
        newFood.transform.position = pos;

        // Add sprite renderer
        SpriteRenderer sr = newFood.AddComponent<SpriteRenderer>();
        sr.sprite = food.platedFoodSprite;

        //hihi lucas here the collider size here i decided to set to the sprite size
        selfcollider.size = selfcollider.gameObject.GetComponent<SpriteRenderer>().size;
        selfscript.isKnifeHeld = parentscript.isKnifeHeld;//same with this where i set the knife held stuff
        // Sorting order increases with each duplicate
        sr.sortingOrder = food.sortingOrder + foodcount;
        //and then here we update the bounds of the testfood
        selfscript.getbounds();
        selfscript.activeFood = selfscript.food;
        //set the active food too
    }


    public List<FoodItem> GetCurrentFoods()
    {
        List<FoodItem> foods = new List<FoodItem>();
        foreach (Transform child in foodContainer)
        {
            TestFood tf = child.GetComponent<TestFood>();
            if (tf != null && tf.food != null)
            {
                foods.Add(tf.food);
            }
        }
        return foods;
    }
}
