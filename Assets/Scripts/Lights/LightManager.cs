using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public enum LightManagerState {
        On,
        Off
    }

    public enum EffectType {
        Flash,
        Sequence,
        ReverseSequence,
        BidirectionalSequence,
        RandomSingle
    }

    private LightManagerState state;
    private EffectType effectType;
    [SerializeField] private List<LightCollection> lightCollections;

    [SerializeField] private float delayTime;
    private float elapsedTime = 0f;

    void Start() {
        state = LightManagerState.On;
        SetEffectType(EffectType.ReverseSequence);
    }

    void Update() {
        if (IsActive()) 
            HandleTimer();
    }

    private void HandleTimer() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= delayTime) {
            elapsedTime = elapsedTime % delayTime;
            HandleEffect();
        }
    }

    private void HandleEffect() {
        if (effectType == EffectType.Flash) 
            LightEffectHandler.Flash(lightCollections);
        else if (effectType == EffectType.Sequence)
            LightEffectHandler.Sequence(lightCollections);
        else if (effectType == EffectType.ReverseSequence)
            LightEffectHandler.ReverseSequence(lightCollections);
        else if (effectType == EffectType.BidirectionalSequence)
            LightEffectHandler.BidirectionalSequence(lightCollections);
        else if (effectType == EffectType.RandomSingle)
            LightEffectHandler.RandomSingle(lightCollections);
    }

    public void Activate() { state = LightManagerState.On; }

    public void Deactivate() { 
        state = LightManagerState.Off;
        TurnOffLights();
    }

    public bool IsActive() { return state == LightManagerState.On; }

    public void SetEffectType(EffectType effectType) {
        TurnOffLights();
        this.effectType = effectType; 
    }

    public void TurnOffLights() {
        foreach (LightCollection lc in lightCollections) {
            foreach (Light light in lc.lights) {
                light.TurnOff();
            }
        }
    }

    public void SetDelay(float delayTime) { this.delayTime = delayTime; }
}