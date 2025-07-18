// ╔═══════════════════════════════════╗
// ║   .*.*. Created by HungHD .*.*.   ║
// ╚═══════════════════════════════════╝

using Microsoft.JSInterop;

namespace AboutMe.Services;

public class ThemeService
{
    private readonly IJSRuntime _jsRuntime;
    private string _currentTheme = "dark"; // Mặc định là chế độ tối

    // Sự kiện để thông báo cho các component lắng nghe
    public event Action? OnThemeChanged;

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public string GetCurrentTheme() => _currentTheme;

    // Phương thức để tải chủ đề đã lưu từ Local Storage
    public async Task LoadThemeFromLocalStorage()
    {
        var savedTheme = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "theme");
        if (!string.IsNullOrEmpty(savedTheme))
        {
            _currentTheme = savedTheme;
        }
        else
        {
            // Nếu chưa có chủ đề nào được lưu, lưu mặc định là "dark"
            // và thiết lập currentTheme.
            // Việc thêm class "dark-mode" vào body sẽ do ToggleTheme hoặc
            // một hàm JS interop riêng biệt thực hiện.
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "theme", "dark");
            _currentTheme = "dark";
        }
        // Gọi hàm JS để cập nhật class body dựa trên _currentTheme
        await UpdateBodyClass();
        OnThemeChanged?.Invoke();
    }

    // Phương thức để chuyển đổi chủ đề
    public async Task ToggleTheme()
    {
        _currentTheme = (_currentTheme == "light") ? "dark" : "light";
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "theme", _currentTheme);
        // Gọi hàm JS để cập nhật class body
        await UpdateBodyClass();
        OnThemeChanged?.Invoke(); // Kích hoạt sự kiện để thông báo cho các component
    }

    // Phương thức nội bộ để cập nhật class của body thông qua JS interop
    private async Task UpdateBodyClass()
    {
        await _jsRuntime.InvokeVoidAsync("updateBodyThemeClass", _currentTheme);
    }
}