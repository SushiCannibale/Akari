


public class NoClip : PlayerCheat
{
    protected override void Awake()
    {
        base.Awake();
        Name = "noclip";
        DesacName = "!" + Name;
        ResponseText = "Congratulations, you gained immunity against gravity !";
    }
    public override void Activate()
    {
        base.Activate();
        Player.SetNoClip(true);
    }

    public override void Desactivate()
    {
        base.Desactivate();
        Player.SetNoClip(false);
    }
}