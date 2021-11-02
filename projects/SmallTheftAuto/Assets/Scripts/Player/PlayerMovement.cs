using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 120f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite armedSprite;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private PlayerWeaponController playerWeaponController;
    private bool isWalking;
    private bool isShooting;

    private void Awake()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * rotSpeed* Time.deltaTime;
        var vertical = Input.GetAxis("Vertical") * speed*Time.deltaTime;
        transform.Rotate(0, 0, -horizontal);
        
        isWalking = false;
        isShooting = false;
        animator.enabled = false;
        var activeWeapon = playerWeaponController.ActiveWeapon;
        spriteRenderer.sprite = activeWeapon.WeaponName == WeaponName.BareHands ? defaultSprite : armedSprite;
        
        if (vertical < 0)
        {
            transform.Translate(0,vertical/1.5f,0);
            isWalking = true;
        }
        else
        {
            transform.Translate(0,vertical,0);
            if (Input.GetKey(KeyCode.W))
            {
                isWalking = true;
            }
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0,vertical*1,0);
                isWalking = true;
            }
        }

        if (isWalking)
        {
            PlayWalkingAnimation();
        }
    }
     
    
   void PlayWalkingAnimation()
    {
        if (animator.gameObject.activeSelf)
        {
            animator.enabled = true;
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerWalk");
        }
    }

    void PlayShootingAnimation()
    {
        if (animator.gameObject.activeSelf)
        {
            animator.enabled = true;
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerPistolShoot");
        }
    }
}
