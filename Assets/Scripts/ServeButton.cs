using UnityEngine;

public class ServeButton : MonoBehaviour
{
    [SerializeField] private OrderValidator orderValidator;

    // Linked to Button Onclick event
    public void OnServeButtonPressed()
    {
        if (orderValidator == null)
        {
            Debug.LogWarning("OrderValidator reference missing!");
            return;
        }

        bool isCorrect = orderValidator.Validate();
        if (isCorrect)
        {
            Debug.Log("Order served correctly!");
            // logic for wow money money
        }
        else
        {
            Debug.Log("Order incorrect!");
            // logic for angy customer
            //maybe lose a bit of moolah 
        }
    }
}
