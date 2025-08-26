using UnityEngine;
using TMPro;

public class MoneyCalculation : MonoBehaviour
{
    [SerializeField] private IntSO money;
    [SerializeField] private daytimer dayTimer;
    [SerializeField] private IntSO days; 
    [SerializeField] private TMP_Text totalRevenueText;
    [SerializeField] private TMP_Text rentCostText;
    [SerializeField] private TMP_Text totalMoneyText;

    private int totalRevenue = 0;

    // Call this method whenever the player earns revenue
    public void AddRevenue(int amount)
    {
        totalRevenue += amount;
    }

    public void OnDayEnd()
    {
        // Calculate rent for the current day only
        int rentAmount = (days != null ? days.value : 1) * 50;

        if (money != null)
        {
            money.value -= rentAmount;
            Debug.Log($"Rent deducted for day {days?.value}: {rentAmount}. New balance: {money.value}");
        }

        if (totalRevenueText != null)
            totalRevenueText.text = $"Total Revenue: ${totalRevenue}";

        if (rentCostText != null)
            rentCostText.text = $"Rental Costs: -${rentAmount}";

        if (totalMoneyText != null)
            totalMoneyText.text = $"Total Money: ${money.value}";
    }
}
