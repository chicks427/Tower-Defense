using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float panSpeed = 10f;
	public float panBorderThickness = 10f;
	public float scrollSpeed = 5;
	public float minY = 3f;
	public float maxY = 20f;
	private bool moveable = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			moveable = !moveable;
		if(!moveable)
			return;

		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
		{
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
		{
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
		{
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
		{
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		Vector3 pos = transform.position;
		pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp(pos.y, minY, maxY);
		transform.position = pos;
	}
}
