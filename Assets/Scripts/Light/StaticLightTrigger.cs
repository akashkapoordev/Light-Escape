using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticLightTrigger : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySoundEffect(Sounds.HIT);
            characterController.HealthDecrease();
            Debug.Log("Player Died With static light");
        }
    }
}
