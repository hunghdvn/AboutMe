# Thiết kế: Trang Chính sách bảo mật (Privacy Policy)

- Ngày: 2026-08-19
- Trạng thái: Đã được user duyệt (phiên bản 5: trang riêng 100% cho mỗi app)

## Bối cảnh

- User publish nhiều app/game riêng lên Google Play Store, cần link chính sách bảo mật cho mỗi app.
- Play Store yêu cầu chính sách phải nhắc **tên app** hoặc **entity developer** trong listing → entity: **H2D Dev**.
- Mỗi app có đặc điểm riêng (có/không AdMob, ứng dụng/game, offline/online) → **mỗi app 1 trang riêng hoàn chỉnh, viết tay 100%** (user chọn cách này thay vì template tham số).
- Trang đặt trong repo này (Blazor WASM), deploy tại hunghd.io.vn.

## Thiết kế

1. Mỗi app có 1 file Razor riêng trong `AboutMe/Pages/`, route `@page "/privacy-policy/<app-slug>"`.
   - App đầu tiên: **HTodo** → `PrivacyPolicyHTodo.razor`, route `/privacy-policy/htodo`.
   - URL: `https://hunghd.io.vn/privacy-policy/htodo`.
2. Nội dung tiếng Việt, riêng cho từng app:
   - **HTodo**: ứng dụng ghi việc cần làm, **offline hoàn toàn, không AdMob, không thu thập dữ liệu**, mọi lứa tuổi.
   - Các mục: Giới thiệu (tên app + H2D Dev) → KHÔNG thu thập (kèm offline) → Dữ liệu cục bộ (todo lưu trên thiết bị) → Link bên ngoài → Trẻ em (mọi lứa tuổi) → Thay đổi → Liên hệ.
   - App có AdMob sẽ có thêm mục Quảng cáo; app khác có nội dung tương ứng.
3. Giao diện theo pattern `Home.razor` (wrapper `bg-light min-vh-100`, Bootstrap, dark mode qua `app.css`), **không header**.
4. **Theme luôn light**:
   - `app.js`: path bắt đầu bằng `/privacy-policy` → bỏ qua dark-mode lúc tải trang.
   - Mỗi trang privacy có `OnInitializedAsync` xóa class `dark-mode` (xử lý điều hướng SPA).
5. Trang generic `/privacy-policy` cũ đã bị xóa.

## Kiểm chứng

- `dotnet build` thành công.
- Dev server: `/privacy-policy/htodo` render đúng nội dung HTodo, light theme dù theme đã lưu là dark; home vẫn dark.
