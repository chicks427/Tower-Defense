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
			
		if (!buildManager.CanBuild)
			return;

		if (turret!=null)
		{
			Debug.Log("Can't build there!");
		}
		else
		{
			buildManager.buildTurretOn(this);
			//GameObject turretToBuild = buildManager.GetTurretToBuild();
			//sturret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
		}
	}

	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!buildManager.CanBuild)
			return;

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
