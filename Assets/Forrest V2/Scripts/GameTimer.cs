using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public GameObject AllRitualsCompleted;
    public bool AllRitualsCompletedBool;
    public GameObject RitualCompleted;
    public bool RitualCompletedBool;
    public float TotalTime;// Total Game Time 
    float LastRitualTime;// Time Since Last Ritual
    [SerializeField] float LastRitualTimeGate;//Time To cap Last Ritual Time 
    public int RitualsCompleted;//Number Of Rituals Completed
    bool TempCap;
    public int GameBaseDifficultyCap;//Set By Rituals 
    float GameModifierDifficulty;//Set by Time Since Last Ritual
    public float CurrentDifficulty;//Actual Difficiulty Value Used By Game
    void Start()
    {
        AllRitualsCompletedBool = true;
        RitualCompletedBool = false;
        TempCap = false;
    }
    void FixedUpdate ()
    {
        TotalTime = Time.deltaTime + TotalTime;
        GameBaseDifficultyCap = RitualsCompleted;
        //Debug.Log(LastRitualTime);

        if(LastRitualTime<=LastRitualTimeGate && TempCap == false)
        {
            GameModifierDifficulty = (LastRitualTime/LastRitualTimeGate);
            CalculateGameDifficulty();
            LastRitualTime = Time.deltaTime + LastRitualTime;
        }
        else if(LastRitualTime>LastRitualTimeGate)
        {
            TempCap = true;
            LastRitualTime = 0;
        }
        if (RitualsCompleted == 3 && AllRitualsCompletedBool)
        {
            AllRitualsCompleted.SetActive(true);
            AllRitualsCompletedBool = false;
        }

        CalculateGameDifficulty();

        if (RitualCompletedBool)
        {
            RitualCompleted.SetActive(true);
            RitualCompletedBool = false;
        }

    }
    void CalculateGameDifficulty()
    {
            CurrentDifficulty = (GameBaseDifficultyCap+GameModifierDifficulty);
            
    }
    
    void ChangeGameState()
    {
        GameBaseDifficultyCap = RitualsCompleted;
        

        
    }





}
