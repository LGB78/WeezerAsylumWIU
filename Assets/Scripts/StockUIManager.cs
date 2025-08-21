using TMPro;
using UnityEngine;

public class StockUIManager : MonoBehaviour
{
    [SerializeField] FoodStock[] stocks;
    [SerializeField] TMP_Text[] stockUItext;

    private void Awake()
    {
        updateUI();
    }

    public void updateUI()
    {
        for (int i = 0; i < stocks.Length; i++)
        {
            stockUItext[i].text = stocks[i].stock.ToString();
        }
    }
        
}
