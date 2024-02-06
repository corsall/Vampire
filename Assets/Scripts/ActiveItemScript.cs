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
        
        // Hide the active item image at the start of the game, since the player has no active item
        this.GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255, 0);
        this.GetComponent<UnityEngine.UI.Image>().preserveAspect = true;
    }

    private void Inventory_OnActiveItemChanged(object sender, System.EventArgs e)
    {
        // Show the active item image when the player has an active item
        this.GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255, 255);

        GameObject activeItem = inventory.GetActiveItem();

        Sprite sprite = activeItem.GetComponent<SpriteRenderer>().sprite;

        this.GetComponent<UnityEngine.UI.Image>().sprite = sprite;
    }
}
