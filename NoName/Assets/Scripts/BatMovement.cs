
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class BatMovement : MonoBehaviour
{
    public static BatMovement Instance { get; private set; }
    

    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private float speed = 10;

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
        var curr_position = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            rg.MovePosition(curr_position += Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rg.MovePosition(curr_position += Vector3.right * speed * Time.deltaTime);
        }
    }

    public Vector3 GetBatPosition()
    {
        return transform.position;
    }
}
