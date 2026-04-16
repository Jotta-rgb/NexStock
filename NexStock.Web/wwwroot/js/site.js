function mostrarLoading() {
    const loading = document.getElementById("loading-screen");
    if (loading) {
        loading.classList.add("active");
    }
}

// 🚀 FUNÇÃO DE ENVIO COM DELAY
function enviarComLoading() {
    mostrarLoading();

    setTimeout(() => {
        document.querySelector(".login-box").submit();
    }, 2000); // tempo que você quiser
}

// 🔥 GARANTE QUE SEMPRE SOME NA NOVA PÁGINA
window.addEventListener("load", function () {
    const loading = document.getElementById("loading-screen");
    if (loading) {
        loading.classList.remove("active");
    }
});