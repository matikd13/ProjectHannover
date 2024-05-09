using UnityEngine;
namespace Objects.Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory")]
    public class Item : ScriptableObject
    {
        public new string name = "New Item";
        public Sprite icon = null;
        public bool isImportantItem = false;
    }
}
