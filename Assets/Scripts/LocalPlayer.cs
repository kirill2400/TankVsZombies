using UnityEngine;

public class LocalPlayer : MonoBehaviour
{
    public static HealthSystem HealthSystem;
    public static Transform Transform;

    [SerializeField] private HealthSystem healthSystem = null;

    private int _zombieKilled;

    private void Awake()
    {
        Transform = transform;
        HealthSystem = healthSystem;
    }

    private void OnEnable()
    {
        StaticEvent<ZombieKilledArgs>.Subscribe(OnZombieKilled);
        
        if (!healthSystem)
            return;

        healthSystem.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        StaticEvent<ZombieKilledArgs>.UnSubscribe(OnZombieKilled);
    }

    private void OnPlayerDied(HealthSystem sender)
    {
        healthSystem.Died -= OnPlayerDied;
        gameObject.SetActive(false);
        StaticEvent<GameOverArgs>.InvokeEvent(this, new GameOverArgs(_zombieKilled, Time.time));
    }

    private void OnZombieKilled(object sender, ZombieKilledArgs args)
    {
        _zombieKilled = args.TotalZombieKilled;
    }
}
