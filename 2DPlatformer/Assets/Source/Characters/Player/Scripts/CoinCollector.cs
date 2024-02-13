using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [field: SerializeField] public float Coins = 0;

    public void AddCoin() =>  Coins++;    
}
