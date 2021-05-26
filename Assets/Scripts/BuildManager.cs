using UnityEngine;

public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;

	private TurretBlueprint turretToBuild;
	public GameObject standardTurretPrefab;
	public GameObject missleLauncherPrefab;

	public bool CanBuild { get { return turretToBuild != null; } }

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager");
			return;
		}
		instance = this;
	}

	public void buildTurretOn(Node node)
	{
		if (PlayerStats.Money < turretToBuild.cost)
		{
			Debug.Log("Not enough money to build that. Current amount: " + PlayerStats.Money);
			return;
		}

		PlayerStats.Money -= turretToBuild.cost;
		GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
		node.turret = turret;

		Debug.Log("Turret purchased. Remaining money: " + PlayerStats.Money);
	}

	public void SelectTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;
	}
}
