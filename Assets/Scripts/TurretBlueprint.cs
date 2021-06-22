using System.Collections;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
	public GameObject prefab;
	public int cost;

	public GameObject upgradedPrefab;
	public int upgradeCost;

	public int GetSellAmount(bool isUpgraded)
	{
		if (isUpgraded)
		{
			return (cost + upgradeCost) / 2;
		}
		else
		{
			return cost / 2;
		}
	}
}
