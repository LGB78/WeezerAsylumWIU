using TMPro;
using UnityEngine;

public class StockUIManager : MonoBehaviour
{
    [SerializeField] FoodStock[] stocks;
    [SerializeField] TMP_Text[] stockUItext;
    [SerializeField] TMP_Text price;
    [SerializeField] IntSO money;

    private void Awake()
    {
        updateUI();
    }

    public void updateUI()
    {
        if (price != null) 
        price.text = "$" + money.value;
        for (int i = 0; i < stocks.Length; i++)
        {
            stockUItext[i].text = stocks[i].stock.ToString();
        }
    }
        
}
