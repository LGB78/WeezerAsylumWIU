using UnityEngine;

public class BuySell : MonoBehaviour
{
    [SerializeField] IntSO money;
    [SerializeField] StockUIManager stockUIManager;
    
    public void buy(FoodStock food)
    {
        if ((money.value - food.price) < 0)
        {
            return;
        }
        money.value -= food.price;
        food.stock += food.buyamt;
        if (stockUIManager != null)
        {
            stockUIManager.updateUI();
        }
    }
    public void sell(int price)
    {
        money.value += price;
        if (stockUIManager != null)
        {
            stockUIManager.updateUI();
        }
    }
}
