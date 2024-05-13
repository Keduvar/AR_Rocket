using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button startButton;
    public Button resetButton;

    public GameObject mainUI;
    public GameObject gameUI;
    public GameObject lostUI;

    public GameObject timerText;

    private ARTapToPlaceObject _arTapToPlaceObject;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        resetButton.onClick.AddListener(ResetGame);
    }

    void StartGame()
    {
        mainUI.SetActive(false);
        gameUI.SetActive(true);
        _arTapToPlaceObject.StartGame();
    }

    void ResetGame()
    {
        lostUI.SetActive(false);
        gameUI.SetActive(true);

        timerText.GetComponent<Timer>().ResetTimer();
    }

    public void ShowLostUI()
    {
        gameUI.SetActive(false);
        lostUI.SetActive(true);
    }
    
}
