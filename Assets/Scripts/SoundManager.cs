using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip playerHurtSound, penaltySound;

    private void OnEnable()
    {
        GameEvents.TakeDamage += PlayHurtSound;
        GameEvents.PenaltyFlag += PenaltySound;
    }

    private void OnDisable()
    {
        GameEvents.TakeDamage -= PlayHurtSound;
        GameEvents.PenaltyFlag -= PenaltySound;
    }
    private void PlayHurtSound()
    {
        source.PlayOneShot(playerHurtSound);
    }

    private void PenaltySound()
    {
        source.PlayOneShot(penaltySound);
    }
}
