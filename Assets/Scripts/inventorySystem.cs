using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventorySystem : MonoBehaviour
{

    private Dictionary<inventoryItemData, inventoryItem> m_itemDictionary;
    public List<inventoryItem> inventory { get; private set; }

    public static inventorySystem current;

    private void Awake()
    {
        inventory = new List<inventoryItem>();
        m_itemDictionary = new Dictionary<inventoryItemData, inventoryItem>();
        current = this;
    }

    public inventoryItem Get(inventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out inventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(inventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out inventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            inventoryItem newItem = new inventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }
    }

    public void Remove(inventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out inventoryItem value))
        {
            value.RemoveFromStack();

            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
    }

}
