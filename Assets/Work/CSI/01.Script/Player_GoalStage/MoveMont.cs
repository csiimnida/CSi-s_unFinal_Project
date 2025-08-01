using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))] 
public class MoveMont : MonoBehaviour ,IRestartable
{
    [field:SerializeField]public InputReader _InputReader{get; private set;}
    [SerializeField]private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _Rigidbody2D;
    private Vector2 move;
    private float speed = 10;
    private float JumpPower = 18;
    [SerializeField] private bool banjun;
    private Vector3 startPosition;
    [SerializeField]private LayerMask whatIsGround;

    private void Awake()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _Rigidbody2D.gravityScale = 5;
        startPosition = transform.position;
        
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        try
        {
            _animator = GetComponentInChildren<Animator>();
        }
        catch
        {

        }
    }


    private void Start()
    {
        _InputReader.OnMoveEvent += HandleMoveEvent;
        _InputReader.OnJumpEvent += Jump;
    }
    private void HandleMoveEvent(Vector2 obj)
    {
        move = obj * (banjun ? -1 : 1);
        _spriteRenderer.flipX = move.x < 0;
        if (_animator == null) return;
        if (Mathf.Abs(move.x) > 0)
        {
            
            _animator.Play("Move");
        }
        else
        {
            _animator.Play("Idle");
        }
    }
    private void Jump()
    {
        if (CheckGround())
        {
            _Rigidbody2D.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
    }

    private bool CheckGround()
    {
        foreach (var VARIABLE in Physics2D.OverlapCircleAll(transform.position, 2))
        {
            Debug.Log(VARIABLE.transform.gameObject.name);
            Debug.Log(VARIABLE.transform.tag);

            if (VARIABLE.transform.CompareTag("Ground"))
            {
                return true;
            }
        }

        return false;
    }
    private void Update()
    {
        _Rigidbody2D.velocity = new Vector2((move.x * speed),_Rigidbody2D.velocity.y);

    }

    public void RestartSet()
    {
        transform.position = startPosition;
    }

    public void RestartEnd()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector2.down * 1);
    }

}
