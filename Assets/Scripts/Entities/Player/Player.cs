using System;
using UnityEngine;

public class Player : AbstractLivingEntity, IDamageable
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float baseDamage;
    [SerializeField] private float speed;
    
    public Vector3 hitOffset;
    public float hitRange = 0.5f;
    public LayerMask hitLayer;
    
    private PlayerCamera cam;
    private PlayerLight light;
    
    public float rotationSmoothness;
    public float jumpStrength;
    public float gravity = -9.81f;
    
    private float yVel = 0f;
    private bool canJump = false;

    private CharacterController controller;

    // private bool canMove = true;
    
    /* Cheats */
    private bool MoonJump;
    public bool GetMoonJump() => MoonJump;
    public void SetMoonJump(bool value) => MoonJump = value;

    private bool NoClip;
    public bool GetNoclip() => NoClip;

    public void SetNoClip(bool value) => NoClip = value;

    /* *** */

    protected void Awake()
    {
        DontDestroyOnLoad(this);
        Initialize(maxHealth, speed, baseDamage);
        controller = GetComponent<CharacterController>();
    }

    public void SetCamera(PlayerCamera camera) => cam = camera;
    public void SetLight(PlayerLight pLight) => light = pLight;

    // public void Attack(LivingEntity livingEntity)
    // {
    //     livingEntity.Hurt(BaseDamage);
    // }

    protected void Update()
    {
        Transform camT = cam.transform;
        Vector3 fwd = camT.forward;
        Vector3 side = camT.right;

        fwd *= Input.GetAxis("Vertical") * Speed;
        side *= Input.GetAxis("Horizontal") * Speed;

        Vector3 planeDir = fwd + side;
        planeDir.y = 0;

        Vector3 yDir = new Vector3(0, 0, 0);

        MovementUpdate(ref yDir);
        AttackUpdate();

        controller.Move((planeDir + yDir) * Time.deltaTime);
        
        /* Le joueur regarde dans la direction de son mouvement */
        if (planeDir != Vector3.zero)
        {
            Quaternion toRot = Quaternion.LookRotation(-planeDir, Vector3.up);
            controller.transform.rotation = Quaternion.RotateTowards(controller.transform.rotation, toRot, rotationSmoothness * Time.fixedDeltaTime);
        }
    }

    private void MovementUpdate(ref Vector3 yDir)
    {
        if (NoClip)
        {
            if (Input.GetButton("Jump"))
            {
                yDir.y += Speed;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                yDir.y -= Speed;
            }
        }
        else
        {
            if (controller.isGrounded)
            {
                yVel = 0;
                canJump = true;
            }

            if (Input.GetButtonDown("Jump") && (canJump || MoonJump))
            {
                yVel += jumpStrength;
                canJump = false;
            }
        
            yVel += gravity * Time.deltaTime;
            yDir.y += yVel;
        }
    }

    private void AttackUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Collider[] hits = Physics.OverlapSphere(transform.position + hitOffset, hitRange, hitLayer);
        
            foreach (Collider coll in hits)
            {
                if (coll.gameObject.TryGetComponent<IDamageable>(out IDamageable hitable))
                {
                    hitable.Hurt(BaseDamage); // * damage modifier de l'arme
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position + hitOffset, hitRange);
    }

    public void Hurt(float amount)
    {
        Health -= amount;
        if (Health <= 0)
            Kill();
    }

    public void Kill()
    {
        // Save + Menu de fin
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO
        // enemy layer, alors <Hurt> 
        // if (other.gameObject.layer == )
    }
}