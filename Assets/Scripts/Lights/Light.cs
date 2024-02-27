using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public enum LightState {
        On,
        Off
    }

    [SerializeField] private LightType lightType;
    [SerializeField] private LightState state;
    private SpriteRenderer spriteRenderer;
    
    void Awake() { 
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TurnOn() { 
        spriteRenderer.sprite = lightType.onSprite;
        state = LightState.On;
    }

    public void TurnOff() { 
        spriteRenderer.sprite = lightType.offSprite;
        state = LightState.Off;
    }

    public bool IsOn() { return state == LightState.On; }
}
