using UnityEngine.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 120f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite armedWithPistolSprite;
    [SerializeField] private Sprite armedWithMachineGunSprite;
    private SpriteRenderer spriteRenderer;
    private Animator shootPistolAnimator;
    private Animator shootMachineGunAnimator;
    private PlayerWeaponController playerWeaponController;
    internal bool isWalking;
    internal bool isShooting;

    private void Awake()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;
        shootPistolAnimator = GetComponent<Animator>();
        shootPistolAnimator.enabled = false;
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * rotSpeed* Time.deltaTime;
        var vertical = Input.GetAxis("Vertical") * speed*Time.deltaTime;
        transform.Rotate(0, 0, -horizontal);
        
        isWalking = false;
        shootPistolAnimator.enabled = false;
        var activeWeapon = playerWeaponController.ActiveWeapon;
        spriteRenderer.sprite = activeWeapon.WeaponName == WeaponName.BareHands ? 
            defaultSprite : (activeWeapon.WeaponName == WeaponName.Pistol ? armedWithPistolSprite : armedWithMachineGunSprite);
        
        if (vertical < 0)
        {
            transform.Translate(0,vertical/1.5f,0);
            if (!Input.GetKey(KeyCode.Mouse0))
            {
                isWalking = true;
            }
        }
        else
        {
            transform.Translate(0,vertical,0);
            if ((Input.GetKey(KeyCode.W) && (!Input.GetKey(KeyCode.Mouse0))))
            {
                isWalking = true;
            }
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0,vertical*1,0);
                isWalking = true;
            }
        }

        if (isWalking) PlayWalkingAnimation();
        if (isShooting) PlayShootingAnimation();
    }

    void PlayWalkingAnimation()
    {
        if (shootPistolAnimator.gameObject.activeSelf)
        {
            shootPistolAnimator.enabled = true;
            shootPistolAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerWalk");
        }
    }

    void PlayShootingAnimation()
    {
        if (shootPistolAnimator.gameObject.activeSelf)
        {
            shootPistolAnimator.enabled = true;
            
            if (spriteRenderer.sprite == armedWithMachineGunSprite)
            {
                shootPistolAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerMachineGunShoot");
            }
            else if (spriteRenderer.sprite == armedWithPistolSprite)
            {
                shootPistolAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerPistolShoot");
            }
            else
            {
                shootPistolAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerPunch");
            }
          
        }
    }
}
