// Hàm này sẽ được Blazor gọi thông qua JS Interop
window.updateBodyThemeClass = (theme) => {
    if (theme === 'dark') {
        document.body.classList.add('dark-mode');
    } else {
        document.body.classList.remove('dark-mode');
    }
};

// Khởi tạo theme khi tải trang (cần để tránh "flash" nếu Blazor tải chậm)
// Chỉ chạy hàm này một lần khi trang được tải.
(function () {
    const savedTheme = localStorage.getItem('theme');
    // Mặc định là 'dark-mode' nếu chưa có hoặc là 'dark'
    if (savedTheme === 'dark' || savedTheme === null) {
        document.body.classList.add('dark-mode');
    } else {
        document.body.classList.remove('dark-mode');
    }
})();