using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject prestigeUI;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private TextMeshProUGUI basePower;
    [SerializeField] private TextMeshProUGUI amplifier;
    [SerializeField] private TextMeshProUGUI powerText;




    private void Awake()
    {
        Instance = this;
        if (shopUI != null)
            shopUI.SetActive(false);
        if(prestigeUI != null)
            prestigeUI.SetActive(false);
        if(PauseMenu!=null) 
            PauseMenu.SetActive(false);
        if(winMenu !=null)
            winMenu.SetActive(false);

    }
    private void Start()
    {
        if(GameManager.instance != null)
        {
            basePower.text = "Base Power:" + GameManager.instance.basePower;
            amplifier.text = "Amplifier:" + GameManager.instance.amp;
            powerText.text = "Leg Power:" + GameManager.instance.legPower;
        }
       
    }

    public void WinMenu()
    {
        winMenu.SetActive(true);
    }
    public void ShopButton()
    {
        shopUI.SetActive(!shopUI.activeInHierarchy);
    }
    public void PrestigeButton()
    {
        prestigeUI.SetActive(!prestigeUI.activeInHierarchy);
    }
    public void PauseButton()
    {
        PauseMenu.SetActive(!PauseMenu.activeInHierarchy);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("_MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ChangeBasePowerText()
    {
        basePower.text = "Base Power:" + GameManager.instance.basePower;
    }
    public void ChangeAmplifierText()
    {
        amplifier.text = "Amplifier:" + GameManager.instance.amp;
    }
    public void ChangePowerText()
    {

        powerText.text = "Leg Power:" + GameManager.instance.legPower;
    }
}
