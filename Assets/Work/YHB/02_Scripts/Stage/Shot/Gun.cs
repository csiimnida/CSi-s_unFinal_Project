using Library;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Sprite bulletSprite;
    [SerializeField] private float power, bulletColliderSize;

    private Bullet _bullet;

    private void Awake()
    {
        inputReader.OnMousePosEvent += LookAt;
        inputReader.OnMouseClickEvent += Shoot;
    }

    private void OnDisable()
    {
        inputReader.OnMousePosEvent -= LookAt;
        inputReader.OnMouseClickEvent += Shoot;
    }

    private void Shoot(Vector2 pos)
    {
        _bullet ??= new GameObjectBuilder()
            .SetComponent<SpriteRenderer>(s => s.sprite = bulletSprite)
            .SetComponent<CircleCollider2D>(c =>
            {
                c.isTrigger = true;
                c.offset = Vector2.zero;
                c.radius = bulletColliderSize;
            })
            .SetComponent<Bullet>(b => b.power = power)
            .Build()
            .transform
            .GetComponent<Bullet>();

        _bullet.gameObject.SetActive(true);
        _bullet.Shoot(transform, pos, 1, 3);
    }

    private void LookAt(Vector2 vector)
    {
        Vector2 direction = vector - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
