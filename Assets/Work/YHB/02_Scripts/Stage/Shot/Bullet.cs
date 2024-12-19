using Library;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float power;

    private Rigidbody2D _rid = null;
    private bool _isAttack;

    private void Awake()
    {
        _rid = transform.TryAddComponent<Rigidbody2D>();
    }

    public void Shoot(Transform owner, Vector2 target, float time, float gravity)
    {
        if (_isAttack) return;

        StartCoroutine(ShootCo(owner, target, time, gravity));
    }
    
    public IEnumerator ShootCo(Transform owner, Vector2 target, float time, float gravity)
    {
        transform.position = owner.position;

        Vector2 dir = target - (Vector2)transform.position;

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        _rid.velocity = Vector2.zero;
        _rid.AddForce(dir.normalized * power * gravity, ForceMode2D.Impulse);
        _rid.gravityScale = gravity;
        _isAttack = true;

        yield return new WaitForSeconds(time);

        _isAttack = false;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_rid.velocity.y, _rid.velocity.x) * Mathf.Rad2Deg);
    }
}
