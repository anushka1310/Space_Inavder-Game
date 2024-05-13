using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(() => SceneManager.LoadScene(1));
    }
}
