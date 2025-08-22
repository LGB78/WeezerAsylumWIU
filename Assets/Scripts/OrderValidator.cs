using System.Collections.Generic;
using UnityEngine;

public class OrderValidator : MonoBehaviour
{
    [SerializeField] foodorder orderSO;      // Reference to the ScriptableObject order
    [SerializeField] FoodTarget trayTarget;  // where the player puts food

    // Call this when the player submits the order
    public bool Validate()
    {
        if (orderSO == null || trayTarget == null)
        {
            Debug.LogWarning("Validator missing references!");
            return false;
        }

        List<FoodItem> placed = trayTarget.GetCurrentFoods();
        List<FoodItem> wanted = orderSO.order;

        // 1. Check count
        if (placed.Count != wanted.Count)
        {
            Debug.Log("Wrong number of items!");
            return false;
        }

        // 2. Check contents (ignores sequence)
        foreach (FoodItem wantedItem in wanted)
        {
            bool found = placed.Exists(f => f == wantedItem);
            if (!found)
            {
                Debug.Log("Missing item: " + wantedItem.foodName);
                return false;
            }
        }

        Debug.Log("Order correct!");
        return true;
    }
}
