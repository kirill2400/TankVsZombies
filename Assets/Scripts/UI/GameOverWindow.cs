using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] private GameObject panel = null;
    [SerializeField] private Text zombieKilledCounter = null;
    [SerializeField] private Text timeSurvivedCounter = null;
    [SerializeField] private Button restartButton = null;
    
    private void OnEnable()
    {
        StaticEvent<GameOverArgs>.Subscribe(OnGameOver);
        restartButton.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        StaticEvent<GameOverArgs>.UnSubscribe(OnGameOver);
        restartButton.onClick.RemoveListener(RestartGame);
    }

    private void OnGameOver(object sender, GameOverArgs args)
    {
        panel.SetActive(true);
        zombieKilledCounter.text = args.ZombieKilled.ToString();
        timeSurvivedCounter.text = TimeSpan.FromSeconds(args.TimeSurvived).ToString(@"mm\:ss", CultureInfo.CurrentCulture);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
