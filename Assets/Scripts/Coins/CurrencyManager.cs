using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    [SerializeField] private List<CoinPile> coinPiles;
    [SerializeField] private int currencyAmount;
    [SerializeField] private int insertedCurrencyAmount;

    void Start() {
        Instance = this;
        OrderCoinPiles();
        AddCoinAmount(695);
    }

    public void AddCoinAmount(int amount) {
        currencyAmount += amount;
        int remainingAmount = amount;
        int remainder = amount;
        foreach (CoinPile coinPile in coinPiles) {
            remainder = remainingAmount % coinPile.GetCoinValue();
            remainingAmount = remainingAmount - remainder;
            int coinsToAdd = remainingAmount / coinPile.GetCoinValue();
            for (int i = 0; i < coinsToAdd; i++) {
                coinPile.AddCoin();
            }
            remainingAmount = remainder;
        }
    }

    public void RemoveCoinAmount(int amount) {
        currencyAmount -= amount;
    }

    public void AddInsertedAmount(int amount) {
        insertedCurrencyAmount += amount;
    }

    public void RemoveInsertedAmount(int amount) {
        insertedCurrencyAmount -= amount;
    }

    private void OrderCoinPiles() { coinPiles.Sort(CoinPile.SortByCoinValue); }

    public int GetCurrencyAmount() { return currencyAmount; }

    public int GetInsertedCurrencyAmount() { return insertedCurrencyAmount; }
}