document.querySelector(".login__form").addEventListener("submit", async function (e) {
    e.preventDefault(); // ป้องกัน reload หน้า

    const email = document.getElementById("login-email").value;
    const password = document.getElementById("login-pass").value;

    try {
        const response = await fetch("/api/users/login", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ email, password })
        });

        if (!response.ok) {
            const error = await response.text();
            message("❌ Login failed: " + error);
            return;
        }

        const result = await response.json();
        message("✅ " + result.message);

        // 👉 เปลี่ยนหน้าหลัง login สำเร็จ
        window.location.href = "/Home/Dashboard"; 
    } catch (err) {
        message("❗ Error connecting to server: " + err.message);
    }
});