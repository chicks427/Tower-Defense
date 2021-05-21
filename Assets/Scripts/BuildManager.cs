using UnityEngine;

public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;

	private GameObject turretToBuild;
	public GameObject standardTurretPrefab;
	public GameObject anotherTurretPrefab;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager");
			return;
		}
		instance = this;
	}

	public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}

	public void SetTurretToBuild(GameObject turret)
	{
		turretToBuild = turret;
	}
}
