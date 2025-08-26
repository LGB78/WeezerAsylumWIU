using TMPro;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public int combo;
    TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        combo = 0;
        text = GetComponent<TMP_Text>();
        updatetext();
    }
    public void updatetext()
    {
        text.text = "Combo: " + combo;
    }
    public void comboadd()
    {
        combo++;
    }
    public void combodead()
    {
        combo = 0;
    }


}
