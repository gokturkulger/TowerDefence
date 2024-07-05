using UnityEngine;

public class Turret : MonoBehaviour
{
    public int Level { get; private set; } = 1;
    public Material defaultMaterial;
    public Material selectedMaterial;
    public WeopanSystem weaponSystem;
    public Shoot shoot;
    private Renderer rend;

    void Start()
    {
        //shoot = gameObject.GetComponent<Shoot>();
       
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

        Debug.Log(weaponSystem.firePower+"first");
        //shoot.weaponSystem = weaponSystem;
        weaponSystem.firePower += 5;
       
        Debug.Log(weaponSystem.firePower + "sec");
        Debug.Log("Turret upgraded to level " + Level);
    }

    public int GetUpgradeCost()
    {
        return Level * 200; // Örnek olarak her seviye için maliyet artýþý
    }
}
