using UnityEngine;
using UnityEngine.Events;

public class daytimer : MonoBehaviour
{
    public UnityEvent dayover;
    [SerializeField] float maxtime;
    private Transform t;
    private float currentTime;
    public GameObject clockHand;
    void Start()
    {
        t = clockHand.GetComponent<RectTransform>();
        currentTime = maxtime;
    }

    void Update()
    {
        if (currentTime <= 0 )
        {
            dayover.Invoke();
            enabled = false;
        }
        else
        {
            currentTime -= Time.deltaTime;
            t.localRotation = Quaternion.Euler(0, 0, currentTime / maxtime * 360);
        }
    }
}
