using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 0;
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D collider;
    private bool isTopCoin = false;

    void Awake() {
        DisableTopCoin();
    }

    public void EnableTopCoin() {
        isTopCoin = true;
    }

    public void DisableTopCoin() {
        isTopCoin = false;
    }

    public void ShowCoin() {
        if (isTopCoin)
            animator.SetBool("over", true);
    }

    public void HideCoin() {
        if (isTopCoin)
            animator.SetBool("over", false);
    }

    public void SetValue(int value) { this.value = value; }

    public int GetValue() { return value; }
}