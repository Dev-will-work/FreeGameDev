using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
  [SerializeField] private List<Image> icons = new List<Image>();
  [SerializeField] private List<Text> amounts = new List<Text>();

  public void UpdateUI(Inventory inventory)
  {
    for (int i = 0; i < inventory.GetSize() && i < icons.Count; i++)
    {
      //second cycle and 1 and 3 commands of this cycle were commented
      icons[i].color = new Color(1, 1, 1, 1);
      icons[i].sprite = inventory.GetItem(i).icon;
      //amounts[i].text = inventory.GetAmount(i) > 1 ? inventory.GetAmount(i).ToString() : "";
    }

    for (int i = inventory.GetSize(); i < icons.Count; i++)
    {
      icons[i].color = new Color(1, 1, 1, 0);

      icons[i].sprite = null;
      //amounts[i].text = "";
    }
  }
}