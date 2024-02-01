using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> inventoryItems;
    private GameObject itemInHand;
    private int itemInHandIndex;

    void Start()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            inventoryItems[i] = SpawnItem(inventoryItems[i]);
        }

        AddItem(Resources.Load<GameObject>("Frog_Enemy"));
    }

    void Update()
    {
        // Це не найкращий спосіб, але працює
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventoryItems.Count > 0)
        {
            ChangeItemInHand(inventoryItems[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && inventoryItems.Count > 1)
        {
            ChangeItemInHand(inventoryItems[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && inventoryItems.Count > 2)
        {
            ChangeItemInHand(inventoryItems[2]);
        }
    }

    public void ChangeItemInHand(GameObject newItem)
    {
        if (this.itemInHand == newItem) return;
        
        this.itemInHand = newItem;
        DeactivateAllItems();
        this.itemInHand.SetActive(true);
    }

    private void DeactivateAllItems()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            inventoryItems[i].SetActive(false);
        }
    }

    public void AddItem(GameObject newItem)
    {
        inventoryItems.Add(SpawnItem(newItem));
    }

    public void RemoveItem(GameObject itemToRemove)
    {
        inventoryItems.Remove(itemToRemove);
    }

    /// <summary>
    /// Spawning item in the world creates new GameObject instance not the same as in param
    /// </summary>
    /// <param name="itemPrefab"></param>
    public GameObject SpawnItem(GameObject itemPrefab)
    {
        GameObject spawnedItem = Instantiate(itemPrefab);
        spawnedItem.name = itemPrefab.name;
        spawnedItem.SetActive(true);
        return spawnedItem;
    }
}
