using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 120f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite armedWithPistolSprite;
    [SerializeField] private Sprite armedWithMachineGunSprite;
    private SpriteRenderer spriteRenderer;
    private Animator attackAnimator;
    private Animator shootMachineGunAnimator;
    private PlayerWeaponController playerWeaponController;
    private bool isWalking;
    internal bool isAttacking;

    private void Awake()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;
        attackAnimator = GetComponent<Animator>();
        attackAnimator.enabled = false;
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        var vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Rotate(0, 0, -horizontal);
        isWalking = (!Input.GetKey(KeyCode.Mouse0) && vertical != 0);
        attackAnimator.enabled = false;
        var activeWeapon = playerWeaponController.ActiveWeapon;
        spriteRenderer.sprite = activeWeapon.WeaponName == WeaponName.BareHands ? 
            defaultSprite : (activeWeapon.WeaponName == WeaponName.Pistol ? armedWithPistolSprite : armedWithMachineGunSprite);
        
        transform.Translate(0, GetYBasedOnInput(vertical), 0);

        if (isWalking) PlayWalkingAnimation();
        if (isAttacking) PlayAttackAnimation();
    }

    private float GetYBasedOnInput(float vertical)
    {
        return vertical < 0 ? vertical / 1.5f :
            Input.GetKey(KeyCode.LeftShift) ? vertical * 2 : vertical;
    }

    void PlayWalkingAnimation()
    {
        if (attackAnimator.gameObject.activeSelf)
        {
            attackAnimator.enabled = true;
            attackAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerWalk");
        }
    }

    void PlayAttackAnimation()
    {
        if (attackAnimator.gameObject.activeSelf)
        {
            attackAnimator.enabled = true;
            if (spriteRenderer.sprite == armedWithMachineGunSprite)
            {
                attackAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerMachineGunShoot");
            }
            else if (spriteRenderer.sprite == armedWithPistolSprite)
            {
                attackAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerPistolShoot");
            }
            else
            {
                attackAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerPunch");
            }
          
        }
    }
}
