using UnityEngine;

public class Turret : MonoBehaviour
{
    public int Level { get; private set; } = 1;
    public Material defaultMaterial;
    public Material selectedMaterial;

    private Renderer rend;

    void Start()
    {
       
    }
    private void Awake()
    {
        rend = GetComponent<Renderer>();
        rend.material = defaultMaterial; // Ba�lang��ta varsay�lan materyal atan�r
    }
    private void Update()
    {
        if (rend.material==null)
        {
            rend.material = defaultMaterial;
        }
    }
    void OnMouseDown()
    {
        // Turret'e t�kland���nda UIManager'daki ShowUpgradePanel metodunu �a��r
        UIManager.instance.ShowUpgradePanel(this);

    }

    public void SetSelectedMaterial()
    {
        rend.material = selectedMaterial;
    }

    public void ResetMaterial()
    {
        rend.material = defaultMaterial;
    }

    public void Upgrade()
    {
        Level++;
        // Taretin seviyesine g�re performans veya �zelliklerin artt�r�lmas� yap�labilir
        Debug.Log("Turret upgraded to level " + Level);
    }

    public int GetUpgradeCost()
    {
        return Level * 100; // �rnek olarak her seviye i�in maliyet art���
    }
}
