public interface IAttacker
{
    public ITarget Target { get; set; }
    public void Attack(ITarget target, int damage);
}

public interface ITarget
{
    public void TakeDamage(int damage);
}
