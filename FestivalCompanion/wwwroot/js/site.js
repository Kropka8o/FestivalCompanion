// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const introscherm = document.getElementById("introscherm");
const keuzescherm = document.getElementById("keuzescherm");

setTimeout(() => {
    introscherm.style.opacity = 0;

    introscherm.addEventListener("transitionend", () => {
        introscherm.style.display = "none";
        keuzescherm.style.display = "flex";
    }, { once: true });
}, 2500);
