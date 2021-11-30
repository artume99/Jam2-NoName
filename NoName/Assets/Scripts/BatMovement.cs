
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class BatMovement : MonoBehaviour
{
    public static BatMovement Instance { get; private set; }
    

    // Start is called before the first frame update
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private float speed = 10;

    private bool isMoving;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveHorizontal(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveHorizontal(Vector3.right);
        }
        else
        {
            SetWalkAnimation(false);
        }
    }

    private void MoveHorizontal(Vector3 dir)
    {
        transform.localEulerAngles = new Vector3(0, dir == Vector3.left ? 180 : 0, 0);
        SetWalkAnimation(true);
        rg.MovePosition(transform.position += dir * speed * Time.deltaTime);
    }

    private void SetWalkAnimation(bool moving)
    {
        if(moving != isMoving)
            animator.SetBool(IsWalking, moving);
        isMoving = moving;
    }

    public Vector3 GetBatPosition()
    {
        return transform.position;
    }
}
