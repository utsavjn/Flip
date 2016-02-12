using UnityEngine;
using System.Collections;


public class SoundEffectsHelper : MonoBehaviour
{

    public static SoundEffectsHelper Instance;

    public AudioClip explosionSound;
    public AudioClip playerShotSound;
    public AudioClip enemyShotSound;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void MakeExplosionSound()
    {
        MakeSound(explosionSound);
    }

    public void MakePlayerShotSound()
    {
        MakeSound(playerShotSound);
    }

    public void MakeEnemyShotSound()
    {
        MakeSound(enemyShotSound);
    }

    /// <param name="originalClip"></param>
    private void MakeSound(AudioClip originalClip)
    {
    AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
