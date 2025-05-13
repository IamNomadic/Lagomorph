using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    public PlayerMovement PM;
    public bool Called;
    public bool MovementAnimated;
    public bool ActionAnimated;
    [HideInInspector] public string CurrentTorso;
    [HideInInspector] public string CurrentLeg;
    [HideInInspector] public string CurrentFeet;
    [HideInInspector] public string CurrentHead;
    [HideInInspector] public string CurrentShoulders;
    [HideInInspector] public string CurrentHands;
    [HideInInspector] public string CurrentHair;
   
    public SpriteRenderer SRC;

    public Animator AFeet;
    public Animator ALegs;
    public Animator ATorso;
    public Animator AShoulders;
    public Animator AHead;
    public Animator AHands;
    public Animator AHair;

    // Start is called before the first frame update
    void Start()
    {
        MovementAnimated = true;
        CurrentTorso = "Torso";
        CurrentHead = "Head";
        CurrentFeet = "Feet";
        CurrentShoulders = "Shoulders";
        CurrentLeg = "Legs";
        CurrentHands = "Gloves";
        CurrentHair = "Hair";


    }

    // Update is called once per frame
    void Update()
    {
        if (MovementAnimated && PM.horizontal < 0 && PM.vertical < 0 || MovementAnimated && PM.horizontal > 0 && PM.vertical < 0)
        {

            AFeet.Play("FeetRunLeftDown");
            ALegs.Play("LegsRunLeftUp");
            ATorso.Play("TorsoRunLeftDown");
            AShoulders.Play("ShouldersRunLeftDown");
            AHead.Play("HeadRunLeftDown");
            AHands.Play("HandsRunLeftDown");
            AHair.Play("HairRunLeftDown");
        }
        else if (MovementAnimated && PM.horizontal < 0 && PM.vertical > 0 || MovementAnimated && PM.horizontal > 0 && PM.vertical > 0)
        {


            AFeet.Play("FeetRunLeftUp");
            ALegs.Play("LegsRunLeftDown");
            ATorso.Play("TorsoRunLeftUp");
            AShoulders.Play("ShouldersRunLeftUp");
            AHead.Play("HeadRunLeftUp");
            AHands.Play("HandsRunLeftUp");
            AHair.Play("HairRunLeftUp");
        }
        else if (MovementAnimated && PM.horizontal < 0 || MovementAnimated && PM.horizontal > 0)
        {


            AFeet.Play("FeetRunLeft");
            ALegs.Play("LegsRunLeft");
            ATorso.Play("TorsoRunLeft");
            AShoulders.Play("ShouldersRunLeft");
            AHead.Play("HeadRunLeft");
            AHands.Play("HandsRunLeft");
            AHair.Play("HairRunLeft");
        }
        else if (MovementAnimated && PM.vertical < 0)
        {


            AFeet.Play("FeetRunDown");
            ALegs.Play("LegsRunDown");
            ATorso.Play("TorsoRunDown");
            AShoulders.Play("ShouldersRunDown");
            AHead.Play("HeadRunDown");
            AHands.Play("HandsRunDown");
            AHair.Play("HairRunDown");
        }
        else if (MovementAnimated && PM.vertical > 0)
        {

            AFeet.Play("FeetRunUp");
            ALegs.Play("LegsRunUp");
            ATorso.Play("TorsoRunUp");
            AShoulders.Play("ShouldersRunUp");
            AHead.Play("HeadRunUp");
            AHands.Play("HandsRunUp");
            AHair.Play("HairRunUp");
        }
        else if (MovementAnimated)
        {

            AFeet.Play("FeetIdleDown");
            ALegs.Play("LegsIdleDown");
            ATorso.Play("TorsoIdleDown");
            AShoulders.Play("ShouldersIdleDown");
            AHead.Play("HeadIdleDown");
            AHands.Play("HandsIdleDown");
            AHair.Play("HairIdleDown");
        }
    }
    public void PickUp()
    {
        MovementAnimated = false;
        StartCoroutine(onesec());
    }
    public void PutDown()
    {
        MovementAnimated = false;
        StartCoroutine(onesec());

    }
    public void Dig()
    {
        MovementAnimated = false;
        StartCoroutine(twosec());

    }
    IEnumerator onesec()
    {
        yield return new WaitForSeconds(1);
        MovementAnimated = true;
    }
    IEnumerator twosec()
    {
        yield return new WaitForSeconds(2);
        MovementAnimated = true;
    }
    IEnumerator Refresh()
    {
        
        AFeet.Play(0);
        ALegs.Play(0);
        ATorso.Play(0);
        AShoulders.Play(0);
        AHead.Play(0);
        AHands.Play(0);
        AHair.Play(0);
        yield return null;
    }
    public void Armor1()
    {

        StartCoroutine(Refresh());
        
    }

}
