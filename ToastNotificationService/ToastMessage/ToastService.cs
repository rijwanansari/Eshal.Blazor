//add namespace
namespace ToastNotificationService.ToastMessage;
public class ToastService
{
    public event Action<string, string, int> OnShow;
    public event Action OnHide;

    public void ShowToast(string message, string type = "info", int dismissAfter = 3)
    {
        OnShow?.Invoke(message, type, dismissAfter);
    }

    public void HideToast()
    {
        OnHide?.Invoke();
    }

    public void ShowSuccess(string message, int dismissAfter = 3) => ShowToast(message, "success", dismissAfter);
    public void ShowError(string message, int dismissAfter = 3) => ShowToast(message, "failure", dismissAfter);
    public void ShowWarning(string message, int dismissAfter = 3) => ShowToast(message, "warning", dismissAfter);
    public void ShowInfo(string message, int dismissAfter = 3) => ShowToast(message, "info", dismissAfter);
    public void ShowAlert(string message, int dismissAfter = 3) => ShowToast(message, "alert", dismissAfter);


}

