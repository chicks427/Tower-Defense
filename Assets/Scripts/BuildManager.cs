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
		GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
		node.turret = turret;
	}

	public void SelectTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;
	}
}
