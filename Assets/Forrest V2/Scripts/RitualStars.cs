using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RitualStars : MonoBehaviour
{
    public Sprite RitualFull, RitualEmpty;
    private Image RitualImage;


    private void Awake()
    {
        RitualImage = GetComponent<Image>();
    }

    public void SetRitualImage(RitualStatus status)
    {
        switch (status)
        {
            case RitualStatus.Empty:
                RitualImage.sprite = RitualEmpty;
                break;
            case RitualStatus.Full:
                RitualImage.sprite = RitualFull;
                break;
        }
    }
}

public enum RitualStatus
{
    Empty = 0,
    Full = 1
}