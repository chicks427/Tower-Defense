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

	public void SelectTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;
		selectedNode = null;

		DeselectNode();
	}

	public void SelectNode(Node node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}

		selectedNode = node;
		turretToBuild = null;
		
		nodeUI.SetTarget(node);
	}

	public void DeselectNode()
	{
		selectedNode = null;
		nodeUI.Hide();
	}

	public TurretBlueprint GetTurretToBuild()
	{
		return turretToBuild;
	}
}
