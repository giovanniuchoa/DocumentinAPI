window.addEventListener('load', () => {

    document.querySelectorAll("link[rel='icon']").forEach(e => e.remove());

    const link = document.createElement('link');
    link.rel = 'icon';
    link.type = 'image/x-icon';
    link.href = '/swagger/favicon.ico';
    document.head.appendChild(link);

    const delay = window.location.href.includes("localhost") ? 300 : 3000;

    const interval = setInterval(() => {
        const topbar = document.querySelector('.topbar-wrapper');
        const topbarcolor = document.querySelector('.topbar');
        const info = document.querySelector('.info');
        const authWrapper = document.querySelector('.auth-wrapper');
        const schemeContainer = document.querySelector('.scheme-container');

        if (topbar && info) {
            clearInterval(interval);

            topbarcolor.style.backgroundColor = "rgb(15, 23, 36)";

            topbar.innerHTML = `
                <div style="display: flex; align-items: center; justify-content: space-between; width: 100%;">
                    <div style="display: flex; align-items: center; gap: 10px;">
                        <img src="/swagger/logo.png" alt="Logo" style="height:40px; width:auto;">
                        <span style="font-size: 20px; font-weight: bold; color: #FFFF;">
                            Documentin
                        </span>
                    </div>
                    <div class="custom-auth"></div>
                </div>
            `;

            const customAuthDiv = topbar.querySelector('.custom-auth');
            customAuthDiv.appendChild(authWrapper);

            info.innerHTML = `
                <div style="display: flex; flex-direction: column; gap: 8px; font-family: sans-serif;">
                    <h2 style="font-size: 28px; font-weight: bold; color: #222; margin: 0;">
                        API Documentin
                    </h2>
                    <p style="font-size: 16px; color: #444; margin: 0;">
                        API para gerenciamento empresarial de documentos e tarefas.
                    </p>
                    <a href="mailto:noreply.documentin@gmail.com"
                       style="color: #0078D7; text-decoration: none; font-size: 15px; width: fit-content;">
                       Contato: Giovanni Uchoa
                    </a>
                </div>
            `;

            if (schemeContainer) schemeContainer.remove();

        }
    }, delay);
});
