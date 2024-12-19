using UnityEngine;

public class FollowMouse : MonoSingleton<FollowMouse>
{
    private Texture2D Mouse;
    public bool CanFollow = true;
    private void Start()
    {
        CanFollow = true;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (CanFollow)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);   
        }
    }

    private void OnDisable()
    {
        Cursor.visible = true;
    }
}
