using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ritualbar : MonoBehaviour
{
    public GameObject RitualPrefab;
    public PlayerStats PlayerStats;
    public PlayerMovement PlayerMovement;
    public GameTimer GT;
    private List<RitualStars> Rituals = new();

    private void Start()
    {
        DrawRituals();
    }

    private void OnEnable()
    {
        PlayerStats.OnPlayerDamaged += DrawRituals;
        PlayerMovement.OnPlayerDamaged += DrawRituals;
    }

    private void OnDisable()
    {
        PlayerStats.OnPlayerDamaged -= DrawRituals;
        PlayerMovement.OnPlayerDamaged -= DrawRituals;
    }

    public void DrawRituals()
    {
        ClearRituals();
        var RitualsToMake = (int)(GT.RitualsCompleted);
        for (var i = 0; i < RitualsToMake; i++) CreateEmptyRituals();
        for (var i = 0; i < Rituals.Count; i++)
        {
            Rituals[i].SetRitualImage((RitualStatus)Rituals.Count);
        }
    }


    public void CreateEmptyRituals()
    {
        var newRitual = Instantiate(RitualPrefab);
        newRitual.transform.SetParent(transform);
        newRitual.transform.localScale = Vector3.one;
        var RitualComponent = newRitual.GetComponent<RitualStars>();
        RitualComponent.SetRitualImage(RitualStatus.Empty);
        Rituals.Add(RitualComponent);
    }


    public void ClearRituals()
    {
        foreach (Transform t in transform) Destroy(t.gameObject);
        Rituals = new List<RitualStars>();
    }
}
