using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private bool grounded;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    private bool isAttacking;
    public Transform AttackCheck;
    private CapsuleCollider2D CapsuleCollider2D;
    private AttackTileDestruction attackTileDestruction;
    


    public void Attacking()
    {
        anim.SetTrigger("Attack");
       var colliders = Physics2D.OverlapCircleAll(AttackCheck.position, 0.2f);
        Debug.Log(colliders.Length);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("Enemy"))
            {
                EnemyController enemy = colliders[i].gameObject.GetComponent<EnemyController>();
                enemy.takeDamage();
            }
        }
        isAttacking = false;
    }

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        CapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        attackTileDestruction = GetComponent<AttackTileDestruction>();

        
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(horizontalInput * speed, body.velocity.y);

        //flip player when moving left and right.
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }
        //Set animator parameters
        anim.SetFloat("Speed", Mathf.Abs(body.velocity.x));
        anim.SetBool("grounded", grounded);
        if (!isAttacking && Input.GetButtonDown("Fire1"))
        {
            Attacking();
            isAttacking = true;

        }
        else if(!isAttacking && Input.GetButtonDown("Fire2"))
        {
            isAttacking =true;
            Attacking();
            //attackTileDestruction.DestroyTiles();
        }
        else
        {
            isAttacking = false;
        }
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        grounded = false;
    }
    private void OnAnimatorIK(int layerIndex)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnCollisionEnter2D(Collision collision)
    {
        if(collision.gameObject.tag == "hitable")
        {

        }
    }
    public bool canAttack()
    {
        return isAttacking = false;
    }
}