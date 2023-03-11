using UnityEngine;

public class TestScript : MonoBehaviour
{
    public PlayerStats stats;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            //stats.RemoveCurStamina(10f);
        }
    }
}
