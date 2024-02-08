using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public event EventHandler OnActiveItemChanged;

    [SerializeField]
    private List<GameObject> inventoryItems;
    private GameObject itemInHand;

    void Start()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            inventoryItems[i] = SpawnItem(inventoryItems[i]);
            inventoryItems[i].SetActive(false);
        }
    }

    void Update()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) && inventoryItems.Count > i)
            {
                ChangeItemInHand(inventoryItems[i]);
            }
        }
    }

    private void ChangeItemInHand(GameObject newItem)
    {
        if (this.itemInHand == newItem) return;
        
        this.itemInHand = newItem;
        DeactivateAllItems();
        this.itemInHand.SetActive(true);

        OnActiveItemChanged.Invoke(this, EventArgs.Empty);
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

    public GameObject GetActiveItem()
    {
        return this.itemInHand;
    }

    /// <summary>
    /// Spawning item in the world creates new GameObject instance not the same as in param
    /// </summary>
    /// <param name="itemPrefab"></param>
    private GameObject SpawnItem(GameObject itemPrefab)
    {
        GameObject spawnedItem = Instantiate(itemPrefab);
        spawnedItem.name = itemPrefab.name;
        spawnedItem.SetActive(true);
        return spawnedItem;
    }
}
