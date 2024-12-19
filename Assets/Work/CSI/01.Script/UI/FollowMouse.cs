using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);   
    }

    private void OnDisable()
    {
        Cursor.visible = true;
    }
}
