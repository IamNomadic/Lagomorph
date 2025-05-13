using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public GameObject ApplePrefab;
    public PlayerStats playerHealth;
    public PlayerMovement playerMovement;
    private List<StaminaApple> Apples = new();

    private void Start()
    {
        DrawApples();
    }

    private void OnEnable()
    {
        PlayerStats.OnPlayerDamaged += DrawApples;
        PlayerMovement.OnPlayerDamaged += DrawApples;
    }

    private void OnDisable()
    {
        PlayerStats.OnPlayerDamaged -= DrawApples;
        PlayerMovement.OnPlayerDamaged -= DrawApples;
    }

    public void DrawApples()
    {
        ClearApples();
        float maxStaminaRemainder = playerHealth.MaxHunger % 3;
        var ApplesToMake = (int)(playerHealth.MaxHunger / 3 + maxStaminaRemainder);
        for (var i = 0; i < ApplesToMake; i++) CreateEmptyApples();
        for (var i = 0; i < Apples.Count; i++)
        {
            var StaminaStatusRemainder = Mathf.Clamp(playerHealth.CurrentHunger - i * 3, 0, 3);
            Apples[i].SetAppleImage((StaminaStatus)StaminaStatusRemainder);
        }
    }


    public void CreateEmptyApples()
    {
        var newApple = Instantiate(ApplePrefab);
        newApple.transform.SetParent(transform);
        newApple.transform.localScale = Vector3.one;
        var AppleComponent = newApple.GetComponent<StaminaApple>();
        AppleComponent.SetAppleImage(StaminaStatus.Empty);
        Apples.Add(AppleComponent);
    }


    public void ClearApples()
    {
        foreach (Transform t in transform) Destroy(t.gameObject);
        Apples = new List<StaminaApple>();
    }
}