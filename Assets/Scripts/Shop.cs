using UnityEngine;

public class Shop : MonoBehaviour
{
	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public void PurchaseStandardTurret()
	{
		Debug.Log("Standard turret selected");
		buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
	}

	public void PurchaseAnotherTurret()
	{
		Debug.Log("Another turret selected");
		buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
	}
}
