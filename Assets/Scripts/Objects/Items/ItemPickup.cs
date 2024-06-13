using Player;
using UnityEngine;
namespace Objects.Items
{
    public class ItemPickup : Interactable
    {

        public Item item;

        public void PickUp()
        {
            Debug.Log("Picked up: "+ item.name);
            GameInstance.Instance.playerController.RemoveFocus();
            
            if(GameInstance.Instance.playerInventory.Add(item))
                Destroy(gameObject);
        }

        protected override void Start()
        {
            base.Start();
            
            ContextMenu.Add(("Pick up", PickUp));
        }

    }
}
