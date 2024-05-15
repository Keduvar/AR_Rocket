using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public GameObject uiLost;

    private UIManager _uIManager;
    private float timeLeft = 30f;

    void Start()
    {
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }

    void UpdateTimer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= 1f;
            int minutes = Mathf.FloorToInt(timeLeft / 60);
            int seconds = Mathf.FloorToInt(timeLeft % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            _uIManager = FindObjectOfType<UIManager>();
            _uIManager.ShowLostUI();

            CancelInvoke();
        }
    }

    public void ResetTimer()
    {
        timeLeft = 30f;
        uiLost.SetActive(false);
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }
}
