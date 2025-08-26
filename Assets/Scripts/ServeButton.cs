using UnityEngine;
using UnityEngine.Events;

public class ServeButton : MonoBehaviour
{
    [SerializeField] private OrderValidator orderValidator;
    BuySell buysell;
    [SerializeField] Combo combo;
    public UnityEvent correct;
    public UnityEvent wrong;

    private void Start()
    {
        buysell = GetComponent<BuySell>();
    }

    // Linked to Button Onclick event
    public void OnServeButtonPressed()
    {
        if (orderValidator == null)
        {
            Debug.LogWarning("OrderValidator reference missing!");
            return;
        }

        int price = (int)(orderValidator.orderSO.order.Count * 1.5 + combo.combo);
        bool isCorrect = orderValidator.Validate();
        if (isCorrect)
        {
            Debug.Log("Order served correctly!");
            // logic for wow money money
            buysell.sell(price);
            //combo.combo++;
            correct.Invoke();
        }
        else
        {
            Debug.Log("Order incorrect!");
            // logic for angy customer
            //maybe lose a bit of moolah 
            //combo.combo = 0;
            wrong.Invoke();
        }
        combo.updatetext();
    }
}
