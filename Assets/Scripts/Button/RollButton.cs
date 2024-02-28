 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollButton : MonoBehaviour
{
    [SerializeField] private Roullette[] roullettes;
    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite downSprite;
    [SerializeField] private Sprite upInactiveSprite;
    [SerializeField] private Sprite downInactiveSprite;
    private bool isActive = true;
    private bool isUp = true;
    private SpriteRenderer spriteRenderer;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown() {
        SetIsUp(false);
        foreach (Roullette roullette in roullettes)
        {
            roullette.Turn();
        }
    }

    void OnMouseUp() {
        SetIsUp(true);
    }

    private void HandleButtonSprite() {
        if (isActive) {
            if (isUp)
                spriteRenderer.sprite = upSprite;
            else
                spriteRenderer.sprite = downSprite;
        }
        else {
            if (isUp)
                spriteRenderer.sprite = upInactiveSprite;
            else
                spriteRenderer.sprite = downInactiveSprite;
        }
    }

    public void SetIsActive(bool isActive) {
        this.isActive = isActive;
        HandleButtonSprite();
    }

    public void SetIsUp(bool isUp) {
        this.isUp = isUp;
        HandleButtonSprite();
    }
}
