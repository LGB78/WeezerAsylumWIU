using System.Collections.Generic;
using UnityEngine;

public class OrderValidator : MonoBehaviour
{
    public foodorder orderSO;      // Reference to the ScriptableObject order
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

        //Check count
        if (placed.Count != wanted.Count)
        {
            Debug.Log("Wrong number of items!");
            return false;
        }

        //Check contents 
        foreach (FoodItem placedItem in placed)
        {
            if (!wanted.Contains(placedItem))
            {
                return false;
            }
            wanted.Remove(placedItem);
        }
        if (wanted.Count > 0) return false;


        Debug.Log("Order correct!");
        return true;
    }
}
