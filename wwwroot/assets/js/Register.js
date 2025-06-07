/*=============== SHOW HIDDEN - PASSWORD ===============*/
const showHiddenPass = (loginPass, loginEye) =>{
   const input = document.getElementById(loginPass),
         iconEye = document.getElementById(loginEye)

   iconEye.addEventListener('click', () =>{
      // Change password to text
      if(input.type === 'password'){
         // Switch to text
         input.type = 'text'

         // Icon change
         iconEye.classList.add('ri-eye-line')
         iconEye.classList.remove('ri-eye-off-line')
      } else{
         // Change to password
         input.type = 'password'

         // Icon change
         iconEye.classList.remove('ri-eye-line')
         iconEye.classList.add('ri-eye-off-line')
      }
   })
}

showHiddenPass('login-pass','login-eye')
showHiddenPass('login-pass1','login-eye1')


document.addEventListener('DOMContentLoaded', () => {
  const form = document.querySelector('.login__form');
  if (!form) return;

  form.addEventListener('submit', async (e) => {
    e.preventDefault();

    const username = document.getElementById('username').value.trim();
    const email = document.getElementById('login-email').value.trim();
    const password = document.getElementById('login-pass1').value;
    const confirm = document.getElementById('login-pass').value;

    if (password !== confirm) {
      alert('Passwords do not match');
      return;
    }

    try {
      const response = await fetch('/api/users/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ username, email, password })
      });

      if (!response.ok) {
        const text = await response.text();
        alert(`Registration failed: ${text}`);
        return;
      }

      alert('Registration successful');
      // window.location.href = '/Home/login';
    } catch (err) {
      console.error(err);
      alert('An error occurred while registering.');
    }
  });
});