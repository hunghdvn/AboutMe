# Thiết kế: Trang Chính sách bảo mật (Privacy Policy)

- Ngày: 2026-08-19
- Trạng thái: Đã được user duyệt (phiên bản 4: luôn theme light)

## Bối cảnh

- User sắp publish **các app di động riêng** (không phải website portfolio) lên Google Play Store, cần link chính sách bảo mật.
- Trang chính sách đặt trong repo này (Blazor WASM) để dùng chung cho **nhiều app** → nội dung phải chung chung, không gắn với app cụ thể hay website.
- Đặc điểm chung của các app (do user xác nhận):
  - Chạy offline, **không thu thập dữ liệu cá nhân**, không login, không analytics.
  - Có hiển thị **quảng cáo Google AdMob**.

## Thiết kế

1. File `AboutMe/Pages/PrivacyPolicy.razor`, route `@page "/privacy-policy"`.
   - URL production: `https://hunghd.io.vn/privacy-policy` — dùng làm link Privacy Policy trên Play Console cho nhiều app.
2. Nội dung **tiếng Việt**, chung chung (không nhắc tên app cụ thể, không nhắc website portfolio), gồm các mục:
   1. Giới thiệu (chính sách áp dụng cho các ứng dụng do "chúng tôi" phát hành trên Google Play — không nhắc tên cá nhân cụ thể)
   2. Thông tin KHÔNG thu thập (không đăng ký/đăng nhập, không form, không trực tiếp thu thập thông tin cá nhân)
   3. Quảng cáo (Google AdMob: Google & đối tác có thể thu thập thông tin thiết bị, ID quảng cáo Android, dữ liệu tương tác; người dùng tắt được quảng cáo cá nhân hóa tại adssettings.google.com)
   4. Dữ liệu lưu cục bộ trên thiết bị (chỉ lưu thiết lập, không gửi đi đâu, xóa được)
   5. Liên kết đến trang bên ngoài (chịu chính sách của bên thứ ba)
   6. Trẻ em (ứng dụng phù hợp mọi lứa tuổi; không thu thập cố ý thông tin trẻ dưới 13)
   7. Thay đổi chính sách
   8. Liên hệ (Facebook, GitHub, WhatsApp của developer)
3. Giao diện theo pattern `Home.razor`: wrapper `bg-light min-vh-100`, Bootstrap classes, dark mode qua `app.css` có sẵn. **Không có `<Header />`** (user không muốn header trên trang này).
4. Không sửa Header/nav bar.
5. **Theme luôn light**: trang chính sách luôn hiển thị theme light bất kể theme đã lưu.
   - `app.js`: khi path là `/privacy-policy`, bỏ qua logic dark-mode lúc tải trang (tránh flash dark).
   - `PrivacyPolicy.razor`: `OnInitializedAsync` xóa class `dark-mode` khỏi body (xử lý điều hướng trong SPA).
   - Không ghi đè `localStorage` — theme đã lưu của user được giữ nguyên, home vẫn dark như cũ.

## Kiểm chứng

- `dotnet build` thành công.
- Chạy dev server, mở `/privacy-policy`, xác nhận render đúng nội dung ở cả light/dark mode.
