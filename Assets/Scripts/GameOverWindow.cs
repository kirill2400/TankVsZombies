using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] private GameObject panel = null;
    [SerializeField] private Text zombieKilledCounter = null;
    [SerializeField] private Text timeSurvivedCounter = null;
    
    private void OnEnable()
    {
        StaticEvent<GameOverArgs>.Subscribe(OnGameOver);
    }

    private void OnDisable()
    {
        StaticEvent<GameOverArgs>.UnSubscribe(OnGameOver);
    }

    private void OnGameOver(object sender, GameOverArgs args)
    {
        panel.SetActive(true);
        zombieKilledCounter.text = args.ZombieKilled.ToString();
        timeSurvivedCounter.text = TimeSpan.FromSeconds(args.TimeSurvived).ToString(@"mm\:ss", CultureInfo.CurrentCulture);
    }
}
