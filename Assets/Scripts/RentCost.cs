using UnityEngine;
using TMPro;

public class RentCost : MonoBehaviour
{
    [SerializeField] private IntSO money;
    [SerializeField] private int rentAmount = 100;
    [SerializeField] private daytimer dayTimer;
    [SerializeField] private TMP_Text rentText; // Reference to the TMP_Text for rental cost

    private void Awake()
    {
        if (dayTimer != null)
            dayTimer.dayover.AddListener(DeductRent);
    }

    private void DeductRent()
    {
        if (money != null)
        {
            money.value -= rentAmount;
            Debug.Log("Rent deducted! New balance: " + money.value);
        }
        if (rentText != null)
        {
            rentText.text = $"Rental costs:  ${rentAmount}";
        }
    }
}