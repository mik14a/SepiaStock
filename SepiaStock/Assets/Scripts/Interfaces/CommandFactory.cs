abstract class CommandFactory<T>
{
    public abstract ButtonCommand<T> Create(T command);
}
