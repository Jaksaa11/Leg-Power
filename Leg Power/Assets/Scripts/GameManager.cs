using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int legPower {  get; private set; }
    public int basePower;
    [SerializeField] private Animator anim;
    private void Start()
    {
        legPower = 0;
        basePower = 1;
    }

    public void AddLegPower(int amp)
    {
        legPower += basePower * amp;
    }

    public void Squat()
    {
        AddLegPower(1);
        anim.SetTrigger("Squat");
        Debug.Log(legPower.ToString()); 
    }
}
