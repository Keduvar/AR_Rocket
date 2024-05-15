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
    private Timer _timer;

    void Start()
    {
        _arTapToPlaceObject = FindObjectOfType<ARTapToPlaceObject>();

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

        _timer = FindObjectOfType<Timer>();
        _timer.ResetTimer();
    }

    public void ShowLostUI()
    {
        _arTapToPlaceObject.ClearPlacedObjects();
        gameUI.SetActive(false);
        lostUI.SetActive(true);
    }
}
