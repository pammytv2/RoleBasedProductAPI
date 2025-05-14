# RoleBasedProductAPI
Login 
![image](https://github.com/user-attachments/assets/98894e32-6dc1-4c35-8457-41d865310fef)

Register
![image](https://github.com/user-attachments/assets/062b3f61-0600-480b-b23d-f99fb6ed7732)


fontend Dashboard
![image](https://github.com/user-attachments/assets/8ddf0b2e-7e6f-411e-8298-6bc568ca5b32)


RoleBasedProductAPI/
│
├── Controllers/               # ตัวควบคุม (Controller) ในรูปแบบ MVC
│   ├── HomeController.cs
│   ├── ProductsController.cs
│   └── UserController.cs
│
├── Views/                     # ไฟล์มุมมอง (View) สำหรับแสดงผลบนหน้าเว็บ
│   ├── Home/
│   │   ├── Account/           # มุมมองสำหรับล็อกอิน / สมัครสมาชิก
│   │   │   ├── login.cshtml
│   │   │   └── Register.cshtml
│   │   └── Products/          # มุมมองที่เกี่ยวกับสินค้า
│   │       ├── dashboard.cshtml
│   │       ├── Products.cshtml
│   │       ├── reports.cshtml
│   │       ├── settings.cshtml
│   │       ├── stock-in.cshtml
│   │       └── stock-out.cshtml
│   └── Shared/                # มุมมองที่ใช้ร่วมกัน เช่น layout
│       ├── _ViewImports.cshtml
│       └── _ViewStart.cshtml
│
├── wwwroot/                   # ไฟล์ static ที่จะถูกเรียกใช้จากเบราว์เซอร์
│   ├── assets/
│   │   ├── css/               # ไฟล์ CSS สำหรับตกแต่ง
│   │   │   ├── from.css
│   │   │   ├── menu.css
│   │   │   ├── settings.css
│   │   │   └── styles.css
│   │   ├── js/                # ไฟล์ JavaScript สำหรับการทำงานของหน้าเว็บ
│   │   │   ├── main.js
│   │   │   ├── menubar.js
│   │   │   ├── Register.js
│   │   │   ├── report.js
│   │   │   └── stock-in.js
│   │   └── img/               # รูปภาพต่าง ๆ (ถ้ามี)
│   ├── scss/                  # ไฟล์ SCSS (ถ้ามีการใช้)
│   └── lib/                   # ไฟล์ไลบรารีจากภายนอก เช่น Bootstrap
│
├── Data/                      # ใช้สำหรับไฟล์ที่เกี่ยวกับฐานข้อมูล เช่น context หรือ seed (ถ้ามี)
├── Models/                    # ไฟล์คลาสสำหรับข้อมูล เช่น Entity หรือ ViewModel
├── Properties/launchSettings.json # การตั้งค่าการรันโปรเจกต์
├── appsettings.json           # ไฟล์ตั้งค่าทั่วไปของแอปพลิเคชัน
├── Program.cs                 # จุดเริ่มต้นของโปรเจกต์
├── README.md                  # ไฟล์นี้เอง (คำอธิบายโปรเจกต์)
└── *.csproj / .sln            # ไฟล์โปรเจกต์และโซลูชันของ .NET
