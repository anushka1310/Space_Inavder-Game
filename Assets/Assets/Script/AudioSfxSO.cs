using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Audio Asset", fileName = "new Audio Asset")]
public class AudioSfxSO : ScriptableObject
{
    public AudioClip ExplosionSFX;
    public AudioClip ShootSFX;
    public AudioClip GameOverSFX;
}
