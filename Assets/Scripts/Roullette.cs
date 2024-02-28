using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roullette : MonoBehaviour
{
    [SerializeField] private SpriteRenderer roulletteImage;
    [SerializeField] private SpriteRenderer roulletteImageUp;
    [SerializeField] private SpriteRenderer roulletteImageDown;
    [SerializeField] private Sprite[] icons;

    private float timeTurn;
    private float timeIcon;
    private bool canTurn;
    private int cont;
    public void Turn()
    {
        int iconChosen = Random.Range(0, icons.Length - 1);
        timeTurn = 0;
        timeIcon = 0;
        cont = 0;
        canTurn = true;
    }

    void Update()
    {
        if (canTurn)
        {
            timeTurn += Time.deltaTime;
            timeIcon += Time.deltaTime;
            if(timeTurn >= 2f)
            {
                canTurn = false;
                timeTurn = 0;
                timeIcon = 0;
                cont = 0;
            }
            else if(timeIcon >= 0.05f)
            {
                if(cont != 0) { roulletteImageUp.sprite = icons[cont - 1]; }
                else { roulletteImageUp.sprite = icons[icons.Length - 1]; }

                roulletteImage.sprite = icons[cont];

                if(cont != icons.Length-1) roulletteImageDown.sprite = icons[cont + 1];
                else { roulletteImageDown.sprite = icons[0]; }

                cont++;
                timeIcon = 0;
                if (cont == icons.Length) { cont = 0; }
            }

        }
    }
}
