using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class CollectableItem : MonoBehaviour
{
  [SerializeField] private Item item;
  [SerializeField] private int amount = 1;

  private void OnTriggerEnter(Collider other)
  {
    if (!item) return;

    var inventory = other.GetComponent<Inventory>();

    if (inventory)
    {
      if (inventory.AddItems(item, amount)) {
        Destroy(gameObject);
      }
    }
  }
}