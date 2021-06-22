using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
	public Color hoverColor;
	public Color notEnoughMoneyColor;
	public Vector3 positionOffset;
	private Color startColor;
	private Renderer rend;
	[Header("Optional")]
	public GameObject turret;

	BuildManager buildManager;

	void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
	}

	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (turret!=null)
		{
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.TurretSelected)
		{
			Debug.Log("There is no turret currently selected");
			return;
		}

		BuildTurret(buildManager.GetTurretToBuild());
	}

	void BuildTurret(TurretBlueprint blueprint)
	{
		if (PlayerStats.Money < blueprint.cost)
		{
			Debug.Log("Not enough money to build that. Current amount: " + PlayerStats.Money);
			return;
		}

		PlayerStats.Money -= blueprint.cost;
		GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Debug.Log("Turret purchased");
	}

	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!buildManager.TurretSelected)
		{
			return;
		}

		if (buildManager.CanAfford)
		{
			rend.material.color = hoverColor;
		}
		else
		{
			rend.material.color = notEnoughMoneyColor;
		}
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + positionOffset;
	}
}
