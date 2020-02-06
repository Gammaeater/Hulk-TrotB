using UnityEngine;





[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovment : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public Transform playerCharacter;
    private SpriteRenderer spriteRenderer;
    private float horizontalMove;
    private float chaseRaidus;
    private float attackRadius;
    public GameObject _target;
    private float moveSpeed;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.flipX = playerCharacter.transform.position.x < transform.position.x;

        anim.SetFloat("speed", Mathf.Abs(horizontalMove));
    }

    public void CheckDistance()

    {


        if (Vector2.Distance(_target.transform.position, transform.position) <= chaseRaidus
            && Vector2.Distance(_target.transform.position, transform.position) > attackRadius)
        {

            transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, moveSpeed * Time.deltaTime);

            
            
        }
    }
}
