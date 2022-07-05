using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private float attackCooldown;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.P) && cooldownTimer > attackCooldown)

        Attack();

        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        PlayerMovement playermovement = gameObject.GetComponent<PlayerMovement>();
        playermovement.Attacking();
        playermovement.canAttack();
        anim.SetTrigger("rAttack");
        cooldownTimer = 0;
    }
}

