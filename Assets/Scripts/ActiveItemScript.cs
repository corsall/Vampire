using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ActiveItemScript : MonoBehaviour
{
    private InventorySystem inventory;

    void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<InventorySystem>();
        inventory.OnActiveItemChanged += Inventory_OnActiveItemChanged;
    }

    private void Inventory_OnActiveItemChanged(object sender, System.EventArgs e)
    {
        GameObject activeItem = inventory.GetActiveItem();

        Sprite sprite = activeItem.GetComponent<SpriteRenderer>().sprite;

        this.GetComponent<UnityEngine.UI.Image>().sprite = sprite;
    }
}
