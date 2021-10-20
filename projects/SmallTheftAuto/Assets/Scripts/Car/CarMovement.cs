using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float maxSpeed = 30f;
    public float turnSpeed = 150f;
    private GameObject Player;
    private FollowCamera FollowCamera;
    private SpriteRenderer spriteRenderer;
    public Sprite drivingSkin;
    public Sprite defaultSkin;
    


    private float speed;
    private const KeyCode VehicleInteract = KeyCode.F;

    void Start()
    {
        FollowCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    // private void Start()
    // {
    //     spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    // }

    void Update()
    {
        Debug.Log("CarMovement is activated!!");
        // Changes skin when driving
        spriteRenderer.sprite = drivingSkin;

        
        if (!Player.activeInHierarchy && Input.GetKeyDown(VehicleInteract))
        {
            gameObject.GetComponent<HandlePassenger>().Exit();
            
            // Restores skin when exiting
            spriteRenderer.sprite = defaultSkin;
            return;
        }
        
        var vertical = Input.GetAxis("Vertical") * maxSpeed*Time.deltaTime;
        var horizontal = Input.GetAxis("Horizontal") * (turnSpeed + vertical)* Time.deltaTime;

        if (vertical != 0)
        {
            transform.Rotate(0, 0, -horizontal);
        }

        if (vertical < 0)
        {
            transform.Translate(0,vertical/2,0 );
        }

        else
        {
            transform.Translate(0,vertical,0 );
        }
    }

    // public FollowCamera followCamera;
    // public GameObject player;
    //
    // then we add OnEnable()
    // And in there add: 
    // followCamera.target = this;
    //
    // Then just almost the same thing in OnDisable()
    // followCamera.target = player;
    private void OnEnable()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.SetActive(false);
        
        Debug.Log("CarMovement enabled!");
        FollowCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>();
        FollowCamera.target = gameObject;
    }

    private void OnDisable()
    {
        FollowCamera.target = Player;
    }
}
