namespace FormulaAPI.Core;

public interface IUnityOfWork
{
    IDriverRepository Drivers { get; }
    Task CompleteAsync();
}