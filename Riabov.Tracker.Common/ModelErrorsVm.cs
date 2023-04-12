namespace Riabov.Tracker.Common;

public class ModelErrorsVm
{
    public IEnumerable<string> CommonErrors { get; set; } = Array.Empty<string>();
    public Dictionary<string, string> ModelErrors { get; set; } = new();

    public ModelErrorsVm(Result result)
    {
        ModelErrors = result.ValidationErrors;
        CommonErrors = result.CommonValidationErrors;
    }

    public ModelErrorsVm()
    {
    }
}
