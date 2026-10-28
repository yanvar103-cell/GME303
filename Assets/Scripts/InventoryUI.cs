using System.Text;
using UnityEngine;
using TMPro;

// Put this on any GameObject in the scene (e.g. your Canvas) and drag
// the UI text that should show the inventory into the _inventoryText slot.
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _inventoryText;
    // First line of the list
    [SerializeField] private string _title = "Inventory:";
    // Shown when the list is empty (leave blank to show only the title)
    [SerializeField] private string _emptyText = "(empty)";

    private void Start()
    {
        // Subscribed in Start (not Awake/OnEnable) so InventoryManager.Instance is already set
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnInventoryChanged += RefreshUI;
        else
            Debug.LogWarning("InventoryUI: no InventoryManager found in scene.");

        RefreshUI();
    }

    private void OnDestroy()
    {
        // Always unsubscribe, so the manager doesn't call a destroyed object
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnInventoryChanged -= RefreshUI;
    }

    private void RefreshUI()
    {
        if (_inventoryText == null || InventoryManager.Instance == null)
            return;

        StringBuilder sb = new StringBuilder();
        sb.AppendLine(_title);

        var items = InventoryManager.Instance._inventoryItems;
        if (items.Count == 0)
        {
            sb.AppendLine(_emptyText);
        }
        else
        {
            foreach (var item in items)
                sb.AppendLine("- " + ToReadableName(item.ToString()));
        }

        _inventoryText.text = sb.ToString();
    }

    // Turns "KeycardA" into "Keycard A" for nicer display
    private string ToReadableName(string name)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < name.Length; i++)
        {
            if (i > 0 && char.IsUpper(name[i]))
                sb.Append(' ');
            sb.Append(name[i]);
        }
        return sb.ToString();
    }
}
