using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffectHandler : MonoBehaviour
{
    //Bidirectional variables
    private static bool goingUp = true;

    public static void Flash(List<LightCollection> lightCollections) {
        foreach (LightCollection lc in lightCollections) {
            foreach (Light light in lc.lights) {
                if (light.IsOn())
                    light.TurnOff();
                else
                    light.TurnOn();
            }
        }
    }

    public static void Sequence(List<LightCollection> lightCollections) {
        foreach (LightCollection lc in lightCollections) {
            Light activeLight = lc.lights.Find(it => it.IsOn());
            if (activeLight != null) {
                int index = lc.lights.IndexOf(activeLight);
                activeLight.TurnOff();
                index++;
                if (index < lc.lights.Count)
                    lc.lights[index].TurnOn();
                else
                    lc.lights[0].TurnOn();
            }
            else
                lc.lights[0].TurnOn();
        }
    }

    public static void ReverseSequence(List<LightCollection> lightCollections) {
        foreach (LightCollection lc in lightCollections) {
            Light activeLight = lc.lights.Find(it => it.IsOn());
            if (activeLight != null) {
                int index = lc.lights.IndexOf(activeLight);
                activeLight.TurnOff();
                index--;
                if (index >= 0)
                    lc.lights[index].TurnOn();
                else
                    lc.lights[lc.lights.Count - 1].TurnOn();
            }
            else
                lc.lights[lc.lights.Count - 1].TurnOn();
        }
    }

    public static void BidirectionalSequence(List<LightCollection> lightCollections) {
        foreach (LightCollection lc in lightCollections) {
            Light activeLight = lc.lights.Find(it => it.IsOn());
            if (activeLight != null) {
                int index = 0;
                if (goingUp) {
                    index = lc.lights.IndexOf(activeLight);
                    activeLight.TurnOff();
                    index++;
                    if (index < lc.lights.Count)
                        lc.lights[index].TurnOn();
                    else {
                        goingUp = false;
                        lc.lights[index - 2].TurnOn();
                    }
                }
                else {
                    index = lc.lights.IndexOf(activeLight);
                    activeLight.TurnOff();
                    index--;
                    if (index >= 0)
                        lc.lights[index].TurnOn();
                    else {
                        goingUp = true;
                        lc.lights[1].TurnOn();
                    }
                }
            }
            else
                lc.lights[0].TurnOn();
        }
    }

    public static void RandomSingle(List<LightCollection> lightCollections) {
        foreach (LightCollection lc in lightCollections) {
            Light activeLight = lc.lights.Find(it => it.IsOn());
            if (activeLight != null)
                activeLight.TurnOff();
            int randomIndex = Random.Range(0, lc.lights.Count);
            while (randomIndex == lc.lights.IndexOf(activeLight))
                randomIndex = Random.Range(0, lc.lights.Count);
            lc.lights[randomIndex].TurnOn();
        }
    }
}
