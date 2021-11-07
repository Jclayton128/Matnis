using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioClip crystalDestroyed = null;
    [SerializeField] AudioClip crystalPickUp = null;
    [SerializeField] AudioClip enterGame = null;
    [SerializeField] AudioClip enemyShipDestroyed = null;
    [SerializeField] AudioClip toggleGameMode = null;
    [SerializeField] AudioClip wrongAnswer = null;
    [SerializeField] AudioClip escapeToMainMenu = null;

    AudioSource auso;

    void Start()
    {
        auso = GetComponent<AudioSource>();
    }

    public void PlayCrystalDestroyed()
    {
        auso.PlayOneShot(crystalDestroyed);
    }
    public void PlayCrystalPickUp()
    {
        auso.PlayOneShot(crystalPickUp);
    }

    public void PlayEnterGame()
    {
        auso.PlayOneShot(enterGame);
    }

    public void PlayEnemyShipDestroyed()
    {
        auso.PlayOneShot(enemyShipDestroyed);
    }
    public void PlayToggleGameMode()
    {
        auso.PlayOneShot(toggleGameMode);
    }
    public void PlayWrongAnswer()
    {
        auso.PlayOneShot(wrongAnswer);
    }

    public void PlayEscapeToMainMenu()
    {
        auso.PlayOneShot(escapeToMainMenu);
    }
}
