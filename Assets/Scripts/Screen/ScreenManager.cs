using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenManager : MonoBehaviour
{
    public enum ScreenState {
        Idle
    }

    [SerializeField] private TMP_Text screenText;
    [SerializeField] private ScreenState state;
    [SerializeField] private float idleDelay = 2f;
    private float elapsedTime = 0f;
    [SerializeField] private bool idleShowingCredits = true;

    void Start() {
        state = ScreenState.Idle;
    }

    void Update() {
        HandleTimer();

        if (state == ScreenState.Idle)
            PlayIdle();
    }

    private void HandleTimer() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= ActiveStateDelay()) {
            elapsedTime = elapsedTime % ActiveStateDelay();
            ActiveStateBehaviour();
        }
    }

    private void ActiveStateBehaviour() {
        if (state == ScreenState.Idle)
            idleShowingCredits = !idleShowingCredits;
    }

    private float ActiveStateDelay() {
        if (state == ScreenState.Idle)
            return idleDelay;
        else 
            return 0f;
    }

    private void PlayIdle() {
        if (idleShowingCredits)
            screenText.text = "Credits: " + CurrencyManager.Instance.GetInsertedCurrencyAmount().ToString();
        else
            screenText.text = "PRESS TO PLAY!";
    }

    
}
