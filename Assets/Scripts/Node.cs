using System.Collections;
using UnityEngine;

public class Node : MonoBehaviour
{
	public Color hoverColor;
	private Color startColor;
	private Renderer rend;

	void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	void OnMouseEnter()
	{
		rend.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
