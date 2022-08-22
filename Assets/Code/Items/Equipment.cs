using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    [SerializeField]
    private int armorModifer = 0;
    [SerializeField]
    private int damageModifer = 0;

    public EquipmentSlot equipSlot;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
    }

    public EquipmentSlot getEquipmentType()
    {
        return equipSlot;
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Hand1, Hand2 }