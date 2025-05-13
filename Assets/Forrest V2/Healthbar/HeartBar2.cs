using System.Collections.Generic;
using UnityEngine;

public class HeartBar2 : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerStats playerHealth;
    public PlayerMovement playerMovement;
    private List<HealthHeart> hearts = new();

    private void Start()
    {
        DrawHearts();
    }

    private void OnEnable()
    {
        PlayerStats.OnPlayerDamaged += DrawHearts;
        PlayerMovement.OnPlayerDamaged += DrawHearts;
    }

    private void OnDisable()
    {
        PlayerStats.OnPlayerDamaged -= DrawHearts;
        PlayerMovement.OnPlayerDamaged -= DrawHearts;
    }

    public void DrawHearts()
    {
        ClearHearts();
        float maxHealthRemainder = playerHealth.MaxHealth % 2;
        var heartsToMake = (int)(playerHealth.MaxHealth / 2 + maxHealthRemainder);
        for (var i = 0; i < heartsToMake; i++) CreateEmptyHeart();
        for (var i = 0; i < hearts.Count; i++)
        {
            var heartStatusRemainder = Mathf.Clamp(playerHealth.CurrentHealth - i * 2, 0, 2);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
        }
    }


    public void CreateEmptyHeart()
    {
        var newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);
        newHeart.transform.localScale = Vector3.one;
        var heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }


    public void ClearHearts()
    {
        foreach (Transform t in transform) Destroy(t.gameObject);
        hearts = new List<HealthHeart>();
    }
}