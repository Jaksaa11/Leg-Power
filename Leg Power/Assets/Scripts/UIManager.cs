using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject prestigeUI;
    [SerializeField] private TextMeshProUGUI basePower;
    [SerializeField] private TextMeshProUGUI amplifier;



    private void Awake()
    {
        Instance = this;
        if (shopUI != null)
            shopUI.SetActive(false);
        if(prestigeUI != null)
            prestigeUI.SetActive(false);

        
    }
    private void Start()
    {
        if(GameManager.instance != null)
        {
            basePower.text = "Base Power:" + GameManager.instance.basePower;
            amplifier.text = "Amplifier:" + GameManager.instance.amp;
        }
       
    }
    public void ShopButton()
    {
        shopUI.SetActive(!shopUI.activeInHierarchy);
    }
    public void PrestigeButton()
    {
        prestigeUI.SetActive(!prestigeUI.activeInHierarchy);
    }

    public void ChangeBasePowerText()
    {
        basePower.text = "Base Power:" + GameManager.instance.basePower;
    }
    public void ChangeAmplifierText()
    {
        amplifier.text = "Amplifier:" + GameManager.instance.amp;
    }
}
