using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player/PlayerCharacteristics")]
public class PlayerCharacteristics : ScriptableObject
{
    public float maxHealth;
    public float health;
    [Range(0f, 1f)] public float maxArmor;
    [Range(0f, 1f)] public float armor;
    public float movementSpeed;
    public float rotateSpeed;
}
