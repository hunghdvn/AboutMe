# Thiết kế: Trang Chính sách bảo mật (Privacy Policy)

- Ngày: 2026-08-19
- Trạng thái: Đã được user duyệt (phiên bản 6: HTodo đa ngôn ngữ)

## Bối cảnh

- User publish nhiều app/game riêng lên Google Play Store, cần link chính sách bảo mật cho mỗi app.
- Play Store yêu cầu chính sách phải nhắc **tên app** hoặc **entity developer** trong listing → entity: **H2D Dev**.
- Mỗi app có đặc điểm riêng (có/không AdMob, ứng dụng/game, offline/online) → **mỗi app 1 trang riêng hoàn chỉnh, viết tay 100%** (user chọn cách này thay vì template tham số).
- Trang đặt trong repo này (Blazor WASM), deploy tại hunghd.io.vn.

## Thiết kế

1. Mỗi app có 1 file Razor riêng trong `AboutMe/Pages/`, route `@page "/privacy-policy/<app-slug>"`.
   - App đầu tiên: **HTodo** → `PrivacyPolicyHTodo.razor`, route `/privacy-policy/htodo`.
   - URL: `https://hunghd.io.vn/privacy-policy/htodo`.
2. **HTodo đa ngôn ngữ** (app hỗ trợ 9 ngôn ngữ) — mỗi ngôn ngữ 1 trang riêng hoàn chỉnh, route `/privacy-policy/htodo/<lang>`:
   - `vi` (mặc định, không suffix) · `en` · `es` · `th` · `ru` · `ja` · `ko` · `zh` · `it`
   - File: `PrivacyPolicyHTodo.razor` + `PrivacyPolicyHTodo<Lang>.razor` (en/es/th/ru/ja/ko/zh/it).
   - Nội dung cùng 7 mục, cùng sự thật — chỉ khác ngôn ngữ. Play Console dùng 1 URL (user chọn); app link tới phiên bản khớp ngôn ngữ thiết bị.
3. Nội dung tiếng Việt, riêng cho từng app:
   - **HTodo**: ứng dụng ghi việc cần làm, **offline hoàn toàn, không AdMob, không thu thập dữ liệu**, mọi lứa tuổi.
   - Các mục: Giới thiệu (tên app + H2D Dev) → KHÔNG thu thập (kèm offline) → Dữ liệu cục bộ (todo lưu trên thiết bị) → Link bên ngoài → Trẻ em (mọi lứa tuổi) → Thay đổi → Liên hệ.
   - App có AdMob sẽ có thêm mục Quảng cáo; app khác có nội dung tương ứng.
4. Giao diện theo pattern `Home.razor` (wrapper `bg-light min-vh-100`, Bootstrap, dark mode qua `app.css`), **không header**.
5. **Theme luôn light**:
   - `app.js`: path bắt đầu bằng `/privacy-policy` → bỏ qua dark-mode lúc tải trang.
   - Mỗi trang privacy có `OnInitializedAsync` xóa class `dark-mode` (xử lý điều hướng SPA).
6. Trang generic `/privacy-policy` cũ đã bị xóa.

## Kiểm chứng

- `dotnet build` thành công.
- Dev server: cả 9 URL `/privacy-policy/htodo[/lang]` render đúng ngôn ngữ tương ứng, light theme dù theme đã lưu là dark; home vẫn dark.
