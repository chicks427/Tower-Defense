using UnityEngine;

public class Shop : MonoBehaviour
{
	public TurretBlueprint standardTurret;
	public TurretBlueprint missleLauncher;
	public TurretBlueprint laserBeamer;

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}
	
	public void SelectStandardTurret()
	{
		Debug.Log("Standard turret selected");
		buildManager.SelectTurretToBuild(standardTurret);
	}

	public void SelectMissleLauncher()
	{
		Debug.Log("Missle launcher selected");
		buildManager.SelectTurretToBuild(missleLauncher);
	}

	public void SelectLaserBeamer()
	{
		Debug.Log("Laser beamer selected");
		buildManager.SelectTurretToBuild(laserBeamer);
	}
}
