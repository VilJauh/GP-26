using UnityEngine;

public class CollectibleCount : MonoBehaviour
{
    private TMPro.TextMeshProUGUI uiText;
    private int count;

    private void Awake()
    {
        uiText = GetComponent<TMPro.TextMeshProUGUI>();
    }
    private void Start()
    {
        UpdateCount();
    }

    private void OnEnable()
    {
        Collectible.OnCollected += OnCollectibleCollected;
    }
    private void OnDisable()
    {
        Collectible.OnCollected -= OnCollectibleCollected;
    }

    private void OnCollectibleCollected()
    {
        count++;
        UpdateCount();
    }
    private void UpdateCount()
    {
        uiText.text = $"{count} / {Collectible.total}";

    }
}
