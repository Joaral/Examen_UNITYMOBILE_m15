using UnityEngine;
using UnityEngine.UI;

public class CanvasObligatorioManager : MonoBehaviour
{
    [Header("Otros Settings")]
    public GameObject panelObligatorio;
    public GameObject buttonPanelOP;
    public GameObject buttonClosePanelOP;

    public Canvas Canvas;

    [Header("Paneles De Colores")]
    private HorizontalOrVerticalLayoutGroup[] layoutGroups;


    void Awake()
    {
        RefreshLayoutGroups(); 
    }

    void Update()
    {
        
    }

    void RefreshLayoutGroups()
    {
        layoutGroups = panelObligatorio.GetComponentsInChildren<HorizontalOrVerticalLayoutGroup>();
    }

    public void OpenPanel()
    {
        panelObligatorio.SetActive(true);
        buttonClosePanelOP.SetActive(true);
        buttonPanelOP.SetActive(false);
    }

    public void ExitPanel()
    {
        panelObligatorio.SetActive(false);
        buttonPanelOP.SetActive(true);
        buttonClosePanelOP.SetActive(false);
    }

}
