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
        rend.material = defaultMaterial; // Baþlangýçta varsayýlan materyal atanýr
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
        // Turret'e týklandýðýnda UIManager'daki ShowUpgradePanel metodunu çaðýr
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
        // Taretin seviyesine göre performans veya özelliklerin arttýrýlmasý yapýlabilir
        Debug.Log("Turret upgraded to level " + Level);
    }

    public int GetUpgradeCost()
    {
        return Level * 100; // Örnek olarak her seviye için maliyet artýþý
    }
}
