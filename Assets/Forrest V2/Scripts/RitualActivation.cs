using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualActivation : MonoBehaviour
{
    GameTimer GT;
    float LocalTime;
    public GameObject BunnyTrapAsset;
    BunnyGenerator BG;
    public RitualGenerator RG;
    PlayerStats PS;
    bool RitualComplete;
    bool RitualStarted;
    bool played;
    public string RitualLetter;
    public Animator RitualAnimator;
    public AudioSource RitualSound;
    [SerializeField] RitualZone RitualZone;
    [SerializeField] int AdditionalBunniesToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        GT = GameObject.FindObjectOfType<GameTimer>();
        BG = GameObject.FindObjectOfType<BunnyGenerator>();
        PS = GameObject.FindObjectOfType<PlayerStats>();
        RG = GameObject.FindObjectOfType<RitualGenerator>();
        LocalTime = 5;
        RitualStarted = false;
        played = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (LocalTime>0 && RitualStarted)
        {
            LocalTime = LocalTime - Time.deltaTime;
        }
        else if (LocalTime < 0 && RitualStarted)
        {
            CompleteRitual();
        }
        if (!RitualStarted)
        {
            RitualAnimator.Play("StartRitual"+RitualLetter);
        }
        else if (RitualStarted && !RitualComplete)
        {
            RitualAnimator.Play("Ritual" + RitualLetter);

            if(!played)
            {
                RitualSound.PlayDelayed(3);
                played = true;
            }
            
        }
        else if (RitualComplete)
        {
            RitualAnimator.Play("EndRitual" + RitualLetter);
        }
        if (RitualZone.Detected)
        {
            RG.RitualsToGenerate++;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadBunny") && !RitualStarted)
        {

            GameObject.Destroy(collision.gameObject);
            StartRitual();
        }




    }
    void StartRitual()
    {
        Instantiate(BunnyTrapAsset,this.gameObject.transform);
        RitualStarted = true;
        LocalTime = 10;
    }
 
    public void CompleteRitual()
    {
        if( !RitualComplete)
        {
            GT.RitualCompletedBool = true;
            GT.RitualsCompleted++;
            RitualComplete = true;
            PS.RitualsCompleted++;
            int i = 0;
            while (i < AdditionalBunniesToSpawn)
            {
                i++;
                BG.BunniesToSpawn++;
                BG.SpawnCooldown = 0;
                PS.RefreshHud();
            }
        }
      
    }
}
