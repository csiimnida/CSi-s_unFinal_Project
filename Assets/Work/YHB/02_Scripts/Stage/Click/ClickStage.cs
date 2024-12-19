using Library;
using Unity.VisualScripting;
using UnityEngine;

public class ClickStage : MonoBehaviour
{
    [SerializeField] private Vector2 moveZone;
    private void Awake()
    {
        moveZone /= 2;

        new GameObjectBuilder()
        .SetName("collider")
       .SetActive(true)
        .SetParent(transform)
        .SetPosition(Vector2.zero)
        .SetComponent<PolygonCollider2D>(col =>
        {
            col.pathCount = 1;

            col.usedByComposite = true;

            col.points = new Vector2[10]
            {
                    new Vector2(moveZone.x, moveZone.y),
                    new Vector2(-moveZone.x, moveZone.y),
                    new Vector2(-moveZone.x, -moveZone.y),
                    new Vector2(moveZone.x, -moveZone.y),

                    new Vector2(moveZone.x, -moveZone.y - 1),
                    new Vector2(-moveZone.x - 1, -moveZone.y - 1),
                    new Vector2(-moveZone.x - 1, moveZone.y + 1),
                    new Vector2(moveZone.x + 1, moveZone.y + 1),
                    new Vector2(moveZone.x + 1, -moveZone.y - 1),
                    new Vector2(moveZone.x, -moveZone.y - 1)
            };
        })
        .Build();
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Vector2.zero, moveZone);
    }
#endif
}
