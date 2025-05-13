using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInputActions : MonoBehaviour
{
    private PlayerControls playerInput;
    public PlayerAnimationScript pA;// Animator
    public PlayerMovement pM;// MovementScript

    // Start is called before the first frame update
    void OnEnable()
    {

        pA = GetComponent<PlayerAnimationScript>();
        if (playerInput == null)
        {
            playerInput = new PlayerControls();
            playerInput.ArmorSelect.armor1.performed += i => pA.Armor1();
            playerInput.Movement.Move.performed += i => pM.Move(i.ReadValue<Vector2>());

        }

        playerInput.Enable();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
