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
    
    private float yVel;
    private bool canJump;

    private CharacterController controller;
    
    private Dialogue CurrentDialogue { get; set; }
    private GameObject WithinBoundsOf { get; set; }

    public static Player Instance;
    protected void Awake()
    {
        if (Instance is null)
        {
            DontDestroyOnLoad(this);
            Initialize(maxHealth, speed, baseDamage, true);
            controller = GetComponent<CharacterController>();
        }
        else
            throw new ApplicationException("There are more than one <Player>");
    }

    protected void Update()
    {
        // CanMove = CurrentDialogue != null && !CurrentDialogue.IsActive;
        
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

        if (CanMove)
        {
            controller.Move((planeDir + yDir) * Time.deltaTime);
        
            /* Le joueur regarde dans la direction de son mouvement */
            if (planeDir != Vector3.zero)
            {
                Quaternion toRot = Quaternion.LookRotation(-planeDir, Vector3.up);
                controller.transform.rotation = Quaternion.RotateTowards(controller.transform.rotation, toRot, rotationSmoothness * Time.fixedDeltaTime);
            }
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
        if (WithinBoundsOf is null)
            return;
        
        if (WithinBoundsOf.CompareTag("DialogueTriggerer"))
        {
            DialogueTriggerer dialogueTriggerer = WithinBoundsOf.GetComponent<DialogueTriggerer>();
            CurrentDialogue = dialogueTriggerer.Dialogue;
            dialogueTriggerer.TriggerDialogue();
        }
    }

    public override void Kill() { }

    
    /* Event's Related */

    private void OnTriggerEnter(Collider other)
    {
        WithinBoundsOf = other.gameObject;
        
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
        if (WithinBoundsOf.CompareTag("DialogueTriggerer"))
        {
            DialogueTriggerer dialogueTriggerer = WithinBoundsOf.GetComponent<DialogueTriggerer>();
            dialogueTriggerer.StopDialogue();
            CurrentDialogue = null;
        }
    }

    /* ***************** */
}