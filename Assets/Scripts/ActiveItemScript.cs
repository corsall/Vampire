using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ActiveItemScript : MonoBehaviour
{
    private InventorySystem inventory;
    private UnityEngine.UI.Image image;

    void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<InventorySystem>();
        image = this.GetComponent<UnityEngine.UI.Image>();

        inventory.OnActiveItemChanged += Inventory_OnActiveItemChanged;
        
        // Hide the active item image at the start of the game, since the player has no active item
        this.image.color = new Color(255, 255, 255, 0);
        this.image.preserveAspect = true;
    }

    private void Inventory_OnActiveItemChanged(object sender, System.EventArgs e)
    {
        // Show the active item image when the player has an active item
        this.image.color = new Color(255, 255, 255, 255);

        GameObject activeItem = inventory.GetActiveItem();

        Sprite sprite = activeItem.GetComponent<SpriteRenderer>().sprite;

        this.image.sprite = sprite;
    }
}
