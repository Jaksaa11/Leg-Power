using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int legPower {  get; private set; }
    private int basePower;
    
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
            legPower = 0;
        basePower = 1;
    }

    public void AddLegPower(int amp)
    {
        legPower += basePower * amp;
    }

 
}
