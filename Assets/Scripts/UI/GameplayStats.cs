using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameplayStats : MonoBehaviour
{
    [SerializeField] private GameObject panel = null;
    [SerializeField] private Text zombieKilledCounter = null;
    [SerializeField] private Text timeSurvivedCounter = null;


    private void OnEnable()
    {
        StaticEvent<ZombieKilledArgs>.Subscribe(OnZombieKilled);
        StaticEvent<GameOverArgs>.Subscribe(OnGameOver);
    }

    private void OnDisable()
    {
        StaticEvent<ZombieKilledArgs>.UnSubscribe(OnZombieKilled);
        StaticEvent<GameOverArgs>.UnSubscribe(OnGameOver);
    }

    private void Update()
    {
        timeSurvivedCounter.text = TimeSpan.FromSeconds(Time.timeSinceLevelLoad).ToString(@"mm\:ss", CultureInfo.CurrentCulture);
    }
    
    private void OnZombieKilled(object sender, ZombieKilledArgs args)
    {
        zombieKilledCounter.text = args.TotalZombieKilled.ToString();
    }
    
    private void OnGameOver(object sender, GameOverArgs args)
    {
        panel.SetActive(false);
    }
}
