using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStamina : MonoBehaviour
{
    public GameObject player;
    public float stamina = 5f;
    public float staminaMax = 5f;

    public LevelController levelController;

    
    void Update()
    {
        levelController.UpdateStaminaSlider();
    }

    public void LoseStamina(float amount)
    {
        if (stamina > 0)
            stamina -= amount;
    }

    public void GainStamina(float amount)
    {
        if (stamina < staminaMax)
            stamina += amount;
    }

    
}
