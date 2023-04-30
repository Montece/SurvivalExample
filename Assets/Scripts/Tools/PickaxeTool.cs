using UnityEngine;

public class PickaxeTool : MonoBehaviour, IUsable
{
    public PlayerInventory inventory;
    public Camera PlayerCamera;
    public ItemsDatabase ItemsDatabase;

    public void Use()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        bool isHit = Physics.Raycast(ray, out hit, 4);

        if (isHit)
        {
            StoneLogic stoneLogic = hit.collider.gameObject.GetComponent<StoneLogic>();

            if (stoneLogic != null)
            {
                bool result = inventory.AddToInventory(new Slot()
                {
                    Item = ItemsDatabase.GetItemByID("stone"),
                    Count = 1,
                    Durability = 0
                });

                if (result)
                {
                    stoneLogic.Durability -= 1;
                    if (stoneLogic.Durability <= 0)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}