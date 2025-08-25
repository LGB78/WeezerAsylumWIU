using UnityEngine;
using TMPro;

public class MoneyCalculation : MonoBehaviour
{
    [SerializeField] private IntSO money;
    [SerializeField] private int rentAmount = 100;
    [SerializeField] private daytimer dayTimer;
    [SerializeField] private TMP_Text totalRevenueText;
    [SerializeField] private TMP_Text rentCostText;
    [SerializeField] private TMP_Text totalMoneyText;

    private int totalRevenue = 0;

    private void Awake()
    {
        if (dayTimer != null)
            dayTimer.dayover.AddListener(OnDayEnd);
    }

    // Call this method whenever the player earns revenue (to update ui at the end of the day ig)
    public void AddRevenue(int amount)
    {
        totalRevenue += amount;
    }

    private void OnDayEnd()
    {
        if (money != null)
        {
            money.value -= rentAmount;
            Debug.Log("Rent deducted! New balance: " + money.value);
        }

        if (totalRevenueText != null)
            totalRevenueText.text = $"Total Revenue: ${totalRevenue}";

        if (rentCostText != null)
            rentCostText.text = $"Rental Costs: ${rentAmount}";

        if (totalMoneyText != null)
            totalMoneyText.text = $"Total Money: ${money.value}";
    }
}
