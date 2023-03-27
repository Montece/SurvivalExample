using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Здоровье
    private float MinHealth = 0.0f;
    private float MaxHealth = 100.0f;
    private float CurHealth;
    private float DecHealth = 1.0f;
    //Еда
    private float MinFood = 0.0f;
    private float MaxFood = 100.0f;
    private float CurFood;
    private float DecFood = 0.5f;
    //Вода
    private float MinWater = 0.0f;
    private float MaxWater = 100.0f;
    private float CurWater;
    private float DecWater = 1.0f;
    //Выносливость
    private float MinStamina = 0.0f;
    private float MaxStamina = 100.0f;
    private float CurStamina;

    private void Start()
    {
        SetCurHealth(MaxHealth);
        SetCurFood(MaxFood);
        SetCurWater(MaxWater);
        SetCurStamina(MaxStamina);
    }

    private void Update()
    {
        RemoveCurFood(DecFood * Time.deltaTime);
        RemoveCurWater(DecWater * Time.deltaTime);

        if (GetCurFood() == 0f) RemoveCurHealth(DecHealth * Time.deltaTime);
        if (GetCurWater() == 0f) RemoveCurHealth(DecHealth * Time.deltaTime);
    }

    //Здоровье

    public float GetMaxHealth()
    {
        return MaxHealth;
    }

    public float GetMinHealth()
    {
        return MinHealth;
    }

    public float GetCurHealth()
    {
        return CurHealth;
    }

    public void SetCurHealth(float newCurHealth)
    {
        if (newCurHealth < MinHealth) newCurHealth = MinHealth;
        if (newCurHealth > MaxHealth) newCurHealth = MaxHealth;
        CurHealth = newCurHealth;
    }

    public void AddCurHealth(float addCurHealth)
    {
        SetCurHealth(GetCurHealth() + addCurHealth);
    }

    public void RemoveCurHealth(float removeCurHealth)
    {
        SetCurHealth(GetCurHealth() - removeCurHealth);
    }

    //Еда
    
    public float GetMaxFood()
    {
        return MaxFood;
    }

    public float GetMinFood()
    {
        return MinFood;
    }

    public float GetCurFood()
    {
        return CurFood;
    }

    public void SetCurFood(float newCurFood)
    {
        if (newCurFood < MinFood) newCurFood = MinFood;
        if (newCurFood > MaxFood) newCurFood = MaxFood;
        CurFood = newCurFood;
    }

    public void AddCurFood(float addCurFood)
    {
        SetCurFood(GetCurFood() + addCurFood);
    }

    public void RemoveCurFood(float removeCurFood)
    {
        SetCurFood(GetCurFood() - removeCurFood);
    }

    //Вода
    
    public float GetMaxWater()
    {
        return MaxWater;
    }

    public float GetMinWater()
    {
        return MinWater;
    }

    public float GetCurWater()
    {
        return CurWater;
    }

    public void SetCurWater(float newCurWater)
    {
        if (newCurWater < MinWater) newCurWater = MinWater;
        if (newCurWater > MaxWater) newCurWater = MaxWater;
        CurWater = newCurWater;
    }

    public void AddCurWater(float addCurWater)
    {
        SetCurWater(GetCurWater() + addCurWater);
    }

    public void RemoveCurWater(float removeCurWater)
    {
        SetCurWater(GetCurWater() - removeCurWater);
    }

    //Выносливость

    public float GetMaxStamina()
    {
        return MaxStamina;
    }

    public float GetMinStamina()
    {
        return MinStamina;
    }

    public float GetCurStamina()
    {
        return CurStamina;
    }

    public void SetCurStamina(float newCurStamina)
    {
        if (newCurStamina < MinStamina) newCurStamina = MinStamina;
        if (newCurStamina > MaxStamina) newCurStamina = MaxStamina;
        CurStamina = newCurStamina;
    }

    public void AddCurStamina(float addCurStamina)
    {
        SetCurStamina(GetCurStamina() + addCurStamina);
    }

    public void RemoveCurStamina(float removeCurStamina)
    {
        SetCurStamina(GetCurStamina() - removeCurStamina);
    }
}