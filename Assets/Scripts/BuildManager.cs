using UnityEngine;

public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;

	private TurretBlueprint turretToBuild;
	private Node selectedNode;
	public GameObject standardTurretPrefab;
	public GameObject missleLauncherPrefab;
	public GameObject buildEffect;
	public NodeUI nodeUI;

	public bool TurretSelected { get { return turretToBuild != null; } }
	public bool CanAfford { get { return PlayerStats.Money >= turretToBuild.cost; } }

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager");
			return;
		}
		instance = this;
	}

	public void BuildTurretOn(Node node)
	{
		if (PlayerStats.Money < turretToBuild.cost)
		{
			Debug.Log("Not enough money to build that. Current amount: " + PlayerStats.Money);
			return;
		}

		PlayerStats.Money -= turretToBuild.cost;
		GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
		node.turret = turret;

		GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Debug.Log("Turret purchased. Remaining money: " + PlayerStats.Money);
	}

	public void SelectTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;
		selectedNode = null;
	}

	public void SelectNode(Node node)
	{
		selectedNode = node;
		turretToBuild = null;
		
		nodeUI.SetTarget(node);
	}

	public void LogInfo()
	{
		//turretToBuild = null;
		Debug.Log("turretToBuild is currently" + turretToBuild);
	}

	public TurretBlueprint GetTurretToBuild()
	{
		return turretToBuild;
	}
}
