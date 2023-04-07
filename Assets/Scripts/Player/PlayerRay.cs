using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public PlayerInventory inventory;
    public Camera camera;

    void Update()
    {
        Ray ray = camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        bool isHit = Physics.Raycast(ray, out hit, 4);

        if (isHit)
        {
            SlotInWorld slotInWorld = hit.collider.gameObject.GetComponent<SlotInWorld>();

            if (slotInWorld != null)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    bool result = inventory.AddToInventory(slotInWorld.slot);
                    if (result)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}
