using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPile : MonoBehaviour
{
    [SerializeField] private List<GameObject> coins;
    [SerializeField] private int coinValue;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float coinHeight = 0.25f;

    void OnMouseEnter() {
        GameObject topCoin = GetTopCoin();
        if (topCoin != null)
            topCoin.GetComponent<Coin>().ShowCoin(); 
    }

    void OnMouseExit() {
        GameObject topCoin = GetTopCoin();
        if (topCoin != null)
            topCoin.GetComponent<Coin>().HideCoin(); 
    }

    void OnMouseDown() {
        if (coins.Count > 0) {
            RemoveCoin();
            CurrencyManager.Instance.RemoveCoinAmount(coinValue);
            CurrencyManager.Instance.AddInsertedAmount(coinValue);
        }
    }

    public void AddCoin() {
        GameObject topCoin = GetTopCoin();
        if (topCoin != null) 
            topCoin.GetComponent<Coin>().DisableTopCoin();
        GameObject newCoin = Instantiate(coinPrefab, new Vector3(transform.position.x, transform.position.y + coins.Count * coinHeight, 0f), Quaternion.identity);
        newCoin.transform.parent = gameObject.transform;
        newCoin.GetComponent<Coin>().EnableTopCoin();
        newCoin.GetComponent<Coin>().SetValue(coinValue);
        coins.Add(newCoin);
    }

    public void RemoveCoin() {
        GameObject lastCoin = GetTopCoin();
        if (lastCoin != null) {
            lastCoin.GetComponent<Coin>().DisableTopCoin();
            coins.Remove(lastCoin);
            Destroy(lastCoin);
            lastCoin = GetTopCoin();
            if (lastCoin != null) {
                lastCoin.GetComponent<Coin>().EnableTopCoin();
                lastCoin.GetComponent<Coin>().ShowCoin();
            }
        }
    }

    public int GetCoinCount() {
        return coins.Count;
    }

    public int GetCoinValue() {
        return coinValue;
    }

    private GameObject GetTopCoin() {
        if (coins.Count > 0) 
            return coins[coins.Count - 1];
        else return null;
    }

    public static int SortByCoinValue(CoinPile cp1, CoinPile cp2) {
        return -(cp1.coinValue.CompareTo(cp2.coinValue));
    }
}