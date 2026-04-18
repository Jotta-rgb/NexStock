// ========================================
// 🔥 LOADING
// ========================================
function mostrarLoading() {
    const loading = document.getElementById("loading-screen");
    if (loading) {
        loading.classList.add("active");
    }
}

function enviarComLoading() {
    mostrarLoading();

    setTimeout(() => {
        document.querySelector(".login-box").submit();
    }, 2000);
}

window.addEventListener("load", function () {
    const loading = document.getElementById("loading-screen");
    if (loading) {
        loading.classList.remove("active");
    }
});


// ========================================
// 🔍 BUSCA + 📄 PAGINAÇÃO (INTEGRADO)
// ========================================
document.addEventListener("DOMContentLoaded", function () {

    const input = document.getElementById("buscaTabela");
    const todasLinhas = Array.from(document.querySelectorAll("table tbody tr"));

    let linhasFiltradas = [...todasLinhas];

    const linhasPorPagina = 15;
    let paginaAtual = 1;

    const numerosPaginas = document.getElementById("numerosPaginas");
    const btnAnterior = document.getElementById("btnAnterior");
    const btnProximo = document.getElementById("btnProximo");

    // 🔥 MOSTRAR PÁGINA
    function mostrarPagina(pagina) {
        paginaAtual = pagina;

        // recalcula total sempre
        const totalPaginas = Math.ceil(linhasFiltradas.length / linhasPorPagina);

        // esconde tudo
        todasLinhas.forEach(linha => linha.style.display = "none");

        // mostra só as filtradas da página
        const inicio = (pagina - 1) * linhasPorPagina;
        const fim = inicio + linhasPorPagina;

        linhasFiltradas.forEach((linha, index) => {
            if (index >= inicio && index < fim) {
                linha.style.display = "";
            }
        });

        renderizarNumeros(totalPaginas);
    }

    // 🔢 BOTÕES DE PÁGINA
    function renderizarNumeros(totalPaginas) {
        numerosPaginas.innerHTML = "";

        let inicio = Math.max(1, paginaAtual - 2);
        let fim = Math.min(totalPaginas, paginaAtual + 2);

        // 🔥 PRIMEIRA PÁGINA
        if (inicio > 1) {
            criarBotao(1);

            if (inicio > 2) {
                criarPontos();
            }
        }

        // 🔥 PÁGINAS DO MEIO
        for (let i = inicio; i <= fim; i++) {
            criarBotao(i);
        }

        // 🔥 ÚLTIMA PÁGINA
        if (fim < totalPaginas) {
            if (fim < totalPaginas - 1) {
                criarPontos();
            }

            criarBotao(totalPaginas);
        }
    }

    function criarBotao(numero) {
        const btn = document.createElement("button");
        btn.innerText = numero;

        if (numero === paginaAtual) {
            btn.style.background = "#ff9800";
        }

        btn.onclick = () => mostrarPagina(numero);
        numerosPaginas.appendChild(btn);
    }

    function criarPontos() {
        const span = document.createElement("span");
        span.innerText = "...";
        span.style.margin = "0 5px";
        numerosPaginas.appendChild(span);
    }


    // ⬅️➡️ BOTÕES
    btnAnterior.onclick = () => {
        if (paginaAtual > 1) {
            mostrarPagina(paginaAtual - 1);
        }
    };

    btnProximo.onclick = () => {
        const totalPaginas = Math.ceil(linhasFiltradas.length / linhasPorPagina);

        if (paginaAtual < totalPaginas) {
            mostrarPagina(paginaAtual + 1);
        }
    };

    // 🔍 BUSCA
    if (input) {
        input.addEventListener("keyup", function () {
            const filtro = input.value.toLowerCase();

            linhasFiltradas = todasLinhas.filter(linha =>
                linha.innerText.toLowerCase().includes(filtro)
            );

            paginaAtual = 1;
            mostrarPagina(paginaAtual);
        });
    }

    // 🚀 INICIAL
    mostrarPagina(1);
});


