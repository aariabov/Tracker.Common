namespace Riabov.Tracker.Common.Progress;

public class ProgressRm
{
    public ClientSocketRm SocketInfo { get; set; } = null!;
    public int TaskId { get; set; }
}

public class ProgressRm<T> : ProgressRm
{
    public T Pars { get; set; } = default!;
}
