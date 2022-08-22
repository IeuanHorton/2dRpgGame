using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    [SerializeField]
    private Equipment[] currentEquipment;

    private void Start()
    {
        int slots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[slots];
    }

    public void Equip(Equipment item)
    {
        int slotIndex = (int)item.equipSlot;

        currentEquipment[slotIndex] = item;
    }
}
