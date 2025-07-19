using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public static ShopItem instance;
    [SerializeField] private string itemName;
    [SerializeField] public int price;
    [SerializeField] public Sprite itemSprite;
    [SerializeField] public Button buyButton;
    [SerializeField] public int legPowerBonus;
    [SerializeField] private SpriteRenderer spriteEquip;
    public bool planet;
    public bool bought;
    private bool equipped;
   
    private void Start()
    {
        instance = this;
        if (buyButton != null)
        {
                buyButton.onClick.AddListener(BuyItem);
        }

    }
    private void FixedUpdate()
    {
        if (bought == true)
        {
            if(itemSprite == spriteEquip.sprite)
            {
                buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equipped";
                buyButton.interactable = false;
            }
            else
            {
                buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
                buyButton.interactable = true;
                buyButton.onClick.RemoveAllListeners();
                buyButton.onClick.AddListener(Equip);
            }
        }
        else
        {
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(BuyItem);
        }
        
    }
    public void BuyItem()
    {
            ShopManager.instance.PurchaseItem(this);
            if (GameManager.instance.prestigeCount == 0)
            {
                if (itemName == "Police Car")
                {
                    GameManager.instance.PrestigeStatus(true);
                }
            }
            else if (GameManager.instance.prestigeCount == 1)
            {
                if (itemName == "TruckTank")
                {
                    GameManager.instance.PrestigeStatus(true);
                }
            }
            if (itemName == "Planet")
            {
                planet = true;
                BackgroundChange.instance.Change();
            }
        
      
    }

    public void Equip()
    {
        ShopManager.instance.EquipItem(this);
    }
}
