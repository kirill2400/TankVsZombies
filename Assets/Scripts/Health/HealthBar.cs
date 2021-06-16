using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject panel = null;
    [SerializeField] private Slider slider = null;

    private void OnEnable()
    {
        StaticEvent<GameOverArgs>.Subscribe(OnGameOver);
        
        if (!LocalPlayer.HealthSystem)
            return;

        LocalPlayer.HealthSystem.PlayerHurt += OnPlayerHurt;
    }
    
    private void OnDisable()
    {
        StaticEvent<GameOverArgs>.UnSubscribe(OnGameOver);
        
        if (!LocalPlayer.HealthSystem)
            return;

        LocalPlayer.HealthSystem.PlayerHurt -= OnPlayerHurt;
    }

    private void OnPlayerHurt(float damage)
    {
        slider.value = LocalPlayer.HealthSystem.Health;
    }

    private void OnGameOver(object sender, GameOverArgs args)
    {
        panel.SetActive(false);
    }
}
