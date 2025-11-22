using UnityEngine;
using UnityEngine.Rendering;

public class BuyTimer : MonoBehaviour
{
    public float buyTime = 10f;
    public bool isBuyTimeActive = false;
    public float timeRemaining;
    public int timeFromFloatToInt;

    void Start()
    {
        isBuyTimeActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBuyTimeActive) {
            if (buyTime > 0)
            {
                timeRemaining = buyTime - Time.time;
            }
            if (timeRemaining < 0.001f)
            {
                isBuyTimeActive = false;
                buyTime = 0;
                //int timeFromFloatToInt = Mathf.CeilToInt(timeRemaining);
                Debug.Log("Time Remaining to Buy: " + timeFromFloatToInt.ToString());
            }
        }
    }
}
