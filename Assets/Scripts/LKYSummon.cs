using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LKYSummon : MonoBehaviour
{
    int progress;
    [SerializeField]TMP_Text text;
    public UnityEvent summonlky; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progress = 0;
        updatetext();
    }

    public void addprogress()
    {
        progress += 10;
        updatetext();
    }

    public void resetprogress()
    {
        progress = 0;
        updatetext();
    }
    public void updatetext()
    {
        text.text = progress.ToString() + "%";
        if (progress >= 100)
        {
            text.text = "CLICK TO SUMMON";
        }
    }

    public void summon()
    {
        if (progress < 100)
            return;

        summonlky.Invoke();
    }
}
