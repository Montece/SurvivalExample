using TMPro;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public TMP_Text Description;
    public PlayerInventory inventory;
    public PlayerStats stats;
    public Camera camera;

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        bool isHit = Physics.Raycast(ray, out hit, 4);

        if (isHit)
        {
            SlotInWorld slotInWorld = hit.collider.gameObject.GetComponent<SlotInWorld>();
            WaterWorld waterWorld = hit.collider.gameObject.GetComponent<WaterWorld>();

            if (slotInWorld != null)
            {
                Description.text = $"{slotInWorld.GetSlot().Item.Title} ({slotInWorld.GetSlot().Count}) [F]";

                if (Input.GetKeyDown(KeyCode.F))
                {
                    bool result = inventory.AddToInventory(slotInWorld.GetSlot());
                    if (result)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
            else if (waterWorld != null)
            {
                Description.text = $"Попить [F]";

                if (Input.GetKeyDown(KeyCode.F))
                {
                    stats.AddCurWater(5f);
                }
            }
            else
            {
                Description.text = "";
            }
        }
        else
        {
            Description.text = "";
        }
    }
}
