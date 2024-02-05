using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ActiveItemScript1 : MonoBehaviour
{
    private InventorySystem inventory ;

    void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<InventorySystem>();
        inventory.OnActiveItemChanged += Inventory_OnActiveItemChanged;
    }

    private void Inventory_OnActiveItemChanged(object sender, System.EventArgs e)
    {
        GameObject activeItem = inventory.GetActiveItem();

        this.GetComponent<UnityEngine.UI.Text>().text = activeItem.name;
    }
}
