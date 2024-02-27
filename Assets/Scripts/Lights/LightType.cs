using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Light", menuName = "Lights/LightType", order = 1)]
public class LightType : ScriptableObject
{
    public Sprite onSprite;
    public Sprite offSprite;
}