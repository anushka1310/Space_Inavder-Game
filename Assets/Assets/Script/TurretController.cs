using UnityEngine;

public class TurretController : MonoBehaviour, IDestroyByEnemy
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform shooter;

    public void Kill()
    {
        GameManager.Instance.TriggerGameOver();
        AudioManager.Instance.PlayExplosion();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        float axis = InputManager.Instance.GetRotationAxis();

        Vector3 currentRotation = shooter.localEulerAngles;
        currentRotation.z -= axis * rotateSpeed * Time.deltaTime;
        currentRotation.z = Mathf.Clamp((currentRotation.z <= 180) ? currentRotation.z : -(360 - currentRotation.z), -70, 70); ;
        shooter.localEulerAngles = currentRotation;
    }
}
