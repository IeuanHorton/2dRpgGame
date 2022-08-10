using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new private string name = "New Item";
    private Sprite icon = null;

    public virtual void Use()
    {

    }
}
