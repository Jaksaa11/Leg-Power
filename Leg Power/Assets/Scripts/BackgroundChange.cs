using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public static BackgroundChange instance;
    [SerializeField] GameObject landBackground;
    [SerializeField] GameObject spaceBackground;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        landBackground.SetActive(true);
        spaceBackground.SetActive(false);
    }

    public void Change()
    {
        landBackground.SetActive(false);
        spaceBackground.SetActive(true);
    }
}
