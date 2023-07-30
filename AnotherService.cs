namespace ServicesLifetime;

public interface IAnotherService
{
    void Run();
}

public class AnotherService : IAnotherService
{
    private readonly ILogger<AnotherService> _logger;

    private readonly IOperationSingleton _singletonOperation;
    private readonly IOperationScoped _scopedOperation;
    private readonly IOperationTransient _transientOperation;

    public AnotherService(ILogger<AnotherService> logger, IOperationSingleton singletonOperation, IOperationScoped scopedOperation, IOperationTransient transientOperation)
    {
        _logger = logger;
        _singletonOperation = singletonOperation;
        _scopedOperation = scopedOperation;
        _transientOperation = transientOperation;
    }

    public void Run()
    {
        _logger.LogInformation("Transient: {res}", _transientOperation.OperationId);
        _logger.LogInformation("Scoped: {res}", _scopedOperation.OperationId);
        _logger.LogInformation("Singleton: {res}", _singletonOperation.OperationId);
    }
}
