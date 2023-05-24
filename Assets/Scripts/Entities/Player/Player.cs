using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Sword sword;
    
    private List<GameObject> withinBounds;
    protected void Awake()
    {
        DontDestroyOnLoad(this);
        Initialize(maxHealth, speed, baseDamage, true);
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        sword = GetComponentInChildren<Sword>();
        withinBounds = new List<GameObject>();
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
        {
            if (withinBounds.Count == 0)
                return;
            Interact(GameUtils.Math.CloserTo(withinBounds, gameObject));
        }

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
        sword.Swing();
        Collider[] hits = Physics.OverlapSphere(transform.position + hitOffset, hitRange, hitLayer);
        
        foreach (Collider coll in hits)
        {
            if (coll.gameObject.TryGetComponent(out IDamageable hitable))
            {
                hitable.Hurt(BaseDamage);
            }
        }
    }

    private void Interact(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out IInteractible clickable))
            clickable.Interact(this);
    }

    public override void Kill()
    {
        transform.position = new Vector3(-1, 1, 4);
        SceneManager.LoadScene(GameUtils.Scenes.MainTitle);
    }

    
    /* Event's Related */

    private void OnTriggerEnter(Collider other)
    {
        withinBounds.Add(other.gameObject);

        if (other.CompareTag("DamageProvider"))
        {
            AbstractLivingEntity damager = other.GetComponentInParent<AbstractLivingEntity>();
        
            if (damager.IsAttacking)
                Hurt(damager.BaseDamage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        withinBounds.Remove(other.gameObject);
        // if (WithinBoundsOf.CompareTag("DialogueTriggerer"))
        // {
        //     DialogueTriggerer dialogueTriggerer = WithinBoundsOf.GetComponent<DialogueTriggerer>();
        //     dialogueTriggerer.StopDialogue();
        //     CurrentDialogue = null;
        // }
    }

    /* ***************** */
}