using UnityEngine;

public class StoneGuardian : Boss
{
    /* Finite State Machine */
    private StoneGuardianBaseState currentState;
    
    public StoneGuardianAwakingState AwakingState = new StoneGuardianAwakingState();
    public StoneGuardianIdleState IdleState = new StoneGuardianIdleState(2.0f, 10.0f);
    public StoneGuardianAttackingState AttackingState = new StoneGuardianAttackingState(15.0f);
    public StoneGuardianVulnerableState VulnerableState = new StoneGuardianVulnerableState(5.0f, 10.0f);
    /*          ***         */

    public Animator Animator { get; private set; }
    
    [SerializeField] private float minTrackingDist;
    [SerializeField] private float maxTrackingDist;

    public GuardianCore Core { get; }

    private void Awake()
    {
        Initialize(100.0f, 10.0f, 5.0f);
        Animator = GetComponent<Animator>();
    }
    
    /* Call quand le joueur entre dans la zone de trigger */
    public override void StartFight(Player player)
    {
        Target = player;
        currentState = AwakingState;
        currentState.Start(this);
    }
    
    void Update()
    {
        if (currentState == null) // combat pas encore commencé
            return;
        
        currentState.Update(this);
    }
 
    public void ChangeState(StoneGuardianBaseState nextState)
    {
        currentState.End(this);
        currentState = nextState;
        currentState.Start(this);
    }

    public void Hurt(float amount)
    {
        Health -= amount;
    }
}
