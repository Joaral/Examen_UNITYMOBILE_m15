using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    public RectTransform rect;
    public bool isOpen = false;
    public GameObject inventory;

    [Header("Value Settings")]
    public float value = 50f;
    public float minValue = 0f;
    public float maxValue = 100f;
    private bool isUpdating = false;

    [Header("UI")]
    public Slider sliderHorizontal;

    [Header("Events")]
    public UnityEvent<float> onValueChanged;

    private void Start()
    {
        if (sliderHorizontal != null)
        {
            sliderHorizontal.minValue = minValue;
            sliderHorizontal.maxValue = maxValue;
            sliderHorizontal.value = maxValue/2;
        }

        UpdateUI();
        Apply();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventory.SetActive(true);
        }
    }

    // Cuando mueves slider
    public void OnSliderChanged(float newValue)
    {
        if (isUpdating) return; // Evitar loop infinito
        value = newValue;
        ClampValue();
        UpdateAll();
    }

    void ClampValue()
    {
        value = Mathf.Clamp(value, minValue, maxValue);
    }
    void UpdateAll()
    {
        UpdateUI();
        Apply();
        onValueChanged?.Invoke(value);
    }
    void UpdateUI()
    {
        isUpdating = true;

        if (sliderHorizontal != null)
            sliderHorizontal.value = value;

        isUpdating = false;
    }
    void Apply()
    {
        onValueChanged.Invoke(value);
    }

    public void CloseInventory()
    {
        inventory.SetActive(false);
    }

}
