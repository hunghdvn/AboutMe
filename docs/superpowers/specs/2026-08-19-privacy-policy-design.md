# Thiết kế: Trang Chính sách bảo mật (Privacy Policy)

- Ngày: 2026-08-19
- Trạng thái: Đã được user duyệt (loại bỏ mục link navbar)

## Bối cảnh

- App **HungHD Profile** (hunghd.io.vn) sắp publish lên Google Play Store, cần link chính sách bảo mật.
- App là trang portfolio **Blazor WebAssembly**: không backend, không thu thập dữ liệu cá nhân, không cookie, không analytics.
- Dữ liệu duy nhất: thiết lập theme (dark/light) lưu trong `localStorage` của trình duyệt (không gửi đi đâu).
- Load tài nguyên tĩnh (Bootstrap, Font Awesome) từ CDN jsDelivr & Cloudflare.
- Có link ra Facebook, GitHub, WhatsApp.

## Thiết kế

1. Thêm file `AboutMe/Pages/PrivacyPolicy.razor` với route `@page "/privacy-policy"`.
   - URL production: `https://hunghd.io.vn/privacy-policy` — dùng làm link Privacy Policy trên Play Console.
2. Nội dung viết bằng **tiếng Việt**, gồm các mục:
   1. Giới thiệu (tên app, chủ sở hữu, ngày hiệu lực)
   2. Thông tin KHÔNG thu thập (không đăng ký, không form, không analytics, không cookie)
   3. Dữ liệu lưu cục bộ (theme trong `localStorage`, không gửi đi đâu, xóa được)
   4. Dịch vụ bên thứ ba (CDN jsDelivr/Cloudflare cho Bootstrap & Font Awesome)
   5. Liên kết trang bên ngoài (Facebook, GitHub, WhatsApp — chịu chính sách của bên thứ ba)
   6. Trẻ em (không hướng đến trẻ dưới 13 tuổi)
   7. Thay đổi chính sách
   8. Liên hệ (Facebook, GitHub, WhatsApp)
3. Giao diện theo đúng pattern của `Home.razor`: wrapper `bg-light min-vh-100`, component `<Header />`, Bootstrap classes, hỗ trợ dark mode qua CSS có sẵn (`app.css`).
4. **Không** sửa Header/nav bar.

## Kiểm chứng

- `dotnet build` thành công.
- Chạy dev server, mở `/privacy-policy`, xác nhận trang render đúng nội dung tiếng Việt ở cả light/dark mode.
