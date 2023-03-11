using UnityEngine;
using UnityEngine.UI;

public class GameInterface : MonoBehaviour
{
    public Slider CurHealth_Slider;
    public Slider CurFood_Slider;
    public Slider CurWater_Slider;
    public Slider CurStamina_Slider;

    public PlayerStats stats;

    private void Start()
    {
        CurHealth_Slider.maxValue = stats.GetMaxHealth();
        CurHealth_Slider.minValue = stats.GetMinHealth();

        CurFood_Slider.maxValue = stats.GetMaxFood();
        CurFood_Slider.minValue = stats.GetMinFood();

        CurWater_Slider.maxValue = stats.GetMaxWater();
        CurWater_Slider.minValue = stats.GetMinWater();

        CurStamina_Slider.maxValue = stats.GetMaxStamina();
        CurStamina_Slider.minValue = stats.GetMinStamina();
    }

    private void Update()
    {
        CurHealth_Slider.value = stats.GetCurHealth();
        CurFood_Slider.value = stats.GetCurFood();
        CurWater_Slider.value = stats.GetCurWater();
        CurStamina_Slider.value = stats.GetCurStamina();
    }
}