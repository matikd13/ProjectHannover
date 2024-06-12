using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Objects.Items
{
    public class Inventory : MonoBehaviour
    {

        public delegate void OnItemChanged();

        public OnItemChanged OnItemChangedCallback;

        public int limit = 20;
        public List<Item> items = new List<Item>();

        public bool Add(Item item)
        {
            if (items.Count == limit) return false;

            items.Add(item);

            OnItemChangedCallback?.Invoke();

            return true;
        }

        public bool Remove(Item item)
        {
            if (item.isImportantItem) return false;

            items.Remove(item);
            OnItemChangedCallback?.Invoke();
            return true;
        }
    }
}
