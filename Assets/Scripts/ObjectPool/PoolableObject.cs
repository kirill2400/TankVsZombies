using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    [SerializeField] private string Id = string.Empty;
    
    public string GetPoolableId() => Id;

    private void Reset() => Id = name;
}
