using UnityEngine;
using UnityEngine.Events;

public class daytimer : MonoBehaviour
{
    public UnityEvent dayover;
    [SerializeField] float maxtime;
    void Start()
    {
    }

    void Update()
    {
        maxtime -= Time.deltaTime;
        if (maxtime <= 0 )
        {
            dayover.Invoke();
        }
    }
}
