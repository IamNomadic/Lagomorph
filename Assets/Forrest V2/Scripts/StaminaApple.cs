using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StaminaApple : MonoBehaviour
{
    public Sprite AppleFull, AppleEmpty, AppleTwoThirds, AppleOneThird;
    private Image AppleImage;


    private void Awake()
    {
        AppleImage = GetComponent<Image>();
    }

    public void SetAppleImage(StaminaStatus status)
    {
        switch (status)
        {
            case StaminaStatus.Empty:
                AppleImage.sprite = AppleEmpty;
                break;
            case StaminaStatus.OneThird:
                AppleImage.sprite = AppleOneThird;
                break;
            case StaminaStatus.TwoThirds:
                AppleImage.sprite = AppleTwoThirds;
                break;
            case StaminaStatus.Full:
                AppleImage.sprite = AppleFull;
                break;
        }
    }
}

public enum StaminaStatus
{
    Empty = 0,
    OneThird = 1,
    TwoThirds = 2,
    Full = 3
}
