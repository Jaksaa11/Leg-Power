using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject HTPMenu;
    private void Awake()
    {
        HTPMenu.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene("SquatScene");
    }

    public void HTP()
    {
        HTPMenu.SetActive(!HTPMenu.activeInHierarchy);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
