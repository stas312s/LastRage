using Player.Interfaces;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]

public class PlayerMove : MonoBehaviour, IPlayerPosition
{
    public Transform Transform => transform;
    public Vector2 Position => transform.position;
    
    private Rigidbody2D _rb;
    private Collider2D _collider2D;
    private Vector2 _movement;
    private bool _canMove = false;
    private bool _canJump = false;
    private bool _isFlip = false;
    private int _jumpLayer => LayerMask.GetMask("Ground", "Enemy");
    private float _extraHeight = 0.2f;

    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce = 10f;
    

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
       ReadInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var axis = Input.GetAxis("Horizontal");
        if (_canMove && (!IsWall() || IsGrounded() || (axis < 0 && !_isFlip) || (axis > 0 && _isFlip)  ))
        {
            if((axis < 0 && !_isFlip) || axis > 0 && _isFlip)
            {
                _isFlip = !_isFlip;
                Vector2 flipX = transform.localScale;
                flipX.x *=-1;
                transform.localScale = flipX;
            }
            Vector2 direction = new Vector2(axis * _speed * Time.fixedDeltaTime, _rb.velocity.y);
            _rb.velocity = (direction);
            
        }

        if (_canJump && IsGrounded())
        {
            _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
            _canJump = false;
        }
    }

    private void ReadInput()
    {
        _canMove = Input.GetButton("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            _canJump = true;
        }
    }

    private bool IsWall()
    {
        Vector3 top = _collider2D.bounds.max;
        Vector3 centr = top + Vector3.down;
        Vector3 down = top + Vector3.down * 2;


        RaycastHit2D hit = PlayerRayWall(down);
        RaycastHit2D hit2 = PlayerRayWall(centr);
        RaycastHit2D hit3 = PlayerRayWall(top);
        return hit.collider != null || hit2.collider != null || hit3.collider != null;
    }
    private bool IsGrounded()
    {
        Vector3 center = _collider2D.bounds.center;
        Vector3 centerRight = new Vector3(center.x +0.5f, center.y, center.z);
        Vector3 centerLeft = new Vector3(center.x -0.5f, center.y, center.z);
        
        RaycastHit2D hit = PlayerRayGround(centerRight);
        RaycastHit2D hit2 = PlayerRayGround(centerLeft);
        return hit.collider != null || hit2.collider != null;
    }

    private RaycastHit2D PlayerRayGround(Vector3 origin)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down,
            _collider2D.bounds.extents.y + _extraHeight, _jumpLayer);
        return hit;
    }
    private RaycastHit2D PlayerRayWall(Vector3 origin)
    {
        
        var direction = _isFlip ? Vector2.left : Vector2.right;
        var startPoint = new Vector2(_isFlip ? origin.x - 1 : origin.x, origin.y);
        
        Debug.DrawRay(startPoint, direction, Color.green, 2, false);
        RaycastHit2D hit = Physics2D.Raycast(startPoint, direction,
            _collider2D.bounds.extents.x, LayerMask.GetMask("Ground"));
        return hit;
    }



}
