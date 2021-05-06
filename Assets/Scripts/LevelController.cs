using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Slider staminaSlider;
    public PlayerStamina playerStamina;

    void Awake()
    {
        
    }

    public void UpdateStaminaSlider()
    {
        staminaSlider.value = playerStamina.stamina;
        //Debug.Log("stamina " + staminaSlider.value);
    }
}
