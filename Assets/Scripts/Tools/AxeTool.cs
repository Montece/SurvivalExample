using UnityEngine;

public class AxeTool : MonoBehaviour, IUsable
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
            TreeLogic treeLogic = hit.collider.gameObject.GetComponent<TreeLogic>();

            if (treeLogic != null)
            {
                bool result1 = inventory.AddToInventory(new Slot()
                {
                    Item = ItemsDatabase.GetItemByID("wood"),
                    Count = 1,
                    Durability = 0
                });

                bool result2 = inventory.AddToInventory(new Slot()
                {
                    Item = ItemsDatabase.GetItemByID("stick"),
                    Count = 1,
                    Durability = 0
                });

                if (result1 || result2)
                {
                    treeLogic.Durability -= 1;
                    if (treeLogic.Durability <= 0)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}