// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function toggleForms() {
    const loginForm = document.getElementById('login-form');
    const signupForm = document.getElementById('signup-form');

    if (loginForm.classList.contains('active')) {
        loginForm.classList.remove('active');
        signupForm.classList.add('active');
    } else {
        loginForm.classList.add('active');
        signupForm.classList.remove('active');
    }
}

// Initialize the forms
document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('login-form').classList.add('active');
});
