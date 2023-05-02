using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : AbstractLivingEntity
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float baseDamage;
    [SerializeField] private float speed;
    
    public Vector3 hitOffset;
    public float hitRange = 0.5f;
    public LayerMask hitLayer;

    public float rotationSmoothness;
    public float jumpStrength;
    public float gravity = -9.81f;
    
    private float yVel = 0f;
    private bool canJump = false;

    private CharacterController controller;
    
    private GameObject TriggerWith { get; set; }

    // private bool canMove = true;
    
    // /* Cheats */
    // private bool MoonJump;
    // public bool GetMoonJump() => MoonJump;
    // public void SetMoonJump(bool value) => MoonJump = value;
    //
    // private bool NoClip;
    // public bool GetNoclip() => NoClip;
    //
    // public void SetNoClip(bool value) => NoClip = value;
    //
    // /* *** */

    protected void Awake()
    {
        DontDestroyOnLoad(this);
        Initialize(maxHealth, speed, baseDamage, true);
        controller = GetComponent<CharacterController>();
    }

    // public void Attack(LivingEntity livingEntity)
    // {
    //     livingEntity.Hurt(BaseDamage);
    // }

    protected void Update()
    {
        Transform camT = GameManager.Instance.PlayerCamera.transform;
        Vector3 fwd = camT.forward;
        Vector3 side = camT.right;

        fwd *= Input.GetAxis("Vertical") * Speed;
        side *= Input.GetAxis("Horizontal") * Speed;

        Vector3 planeDir = fwd + side;
        planeDir.y = 0;

        Vector3 yDir = new Vector3(0, 0, 0);
        
        if (Input.GetButtonDown("Fire1"))
            HandleAttack();
        
        HandleMove(ref yDir);
        
        if (Input.GetKeyDown(GameUtils.Keys.INTERACT))
            HandleInteraction();

        controller.Move((planeDir + yDir) * Time.deltaTime);
        
        /* Le joueur regarde dans la direction de son mouvement */
        if (planeDir != Vector3.zero)
        {
            Quaternion toRot = Quaternion.LookRotation(-planeDir, Vector3.up);
            controller.transform.rotation = Quaternion.RotateTowards(controller.transform.rotation, toRot, rotationSmoothness * Time.fixedDeltaTime);
        }
    }

    private void HandleMove(ref Vector3 yDir)
    {
        if (controller.isGrounded)
        {
            yVel = 0;
            canJump = true;
        }
        
        if (Input.GetButtonDown("Jump") && canJump)
        {
            yVel += jumpStrength;
            canJump = false;
        }
        
        yVel += gravity * Time.deltaTime;
        yDir.y += yVel;
    }

    private void HandleAttack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position + hitOffset, hitRange, hitLayer);
        
        foreach (Collider coll in hits)
        {
            if (coll.gameObject.TryGetComponent(out IDamageable hitable))
            {
                hitable.Hurt(BaseDamage);
            }
        }
    }

    private void HandleInteraction()
    {
        if (TriggerWith is null)
            return;
        
        if (TriggerWith.CompareTag("DialogueTriggerer"))
        {
            TriggerWith.GetComponent<DialogueTriggerer>().TriggerDialogue();
        }
    }

    public override void Kill() { }

    
    /* Event's Related */

    private void OnTriggerEnter(Collider other)
    {
        TriggerWith = other.gameObject;
        
        if (other.CompareTag("DamageProvider"))
            HandleDamage(other);
    }

    private void HandleDamage(Collider other)
    {
        AbstractLivingEntity damager = other.GetComponentInParent<AbstractLivingEntity>();
        
        if (damager.IsAttacking)
            Hurt(damager.BaseDamage);
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerWith = null;
    }
    
    /* ***************** */
}