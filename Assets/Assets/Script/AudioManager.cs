using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource audioScource;
    [SerializeField] private AudioSfxSO audioAsset;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlayShoot()
    {
        audioScource.PlayOneShot(audioAsset.ShootSFX, 0.5f);
    }

    public void PlayExplosion()
    {
        audioScource.PlayOneShot(audioAsset.ExplosionSFX, 0.5f);
    }

    public void GameOverSfx()
    {
        audioScource.clip = audioAsset.GameOverSFX;
        audioScource.loop = false;
        audioScource.Play();
    }
}
