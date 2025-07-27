async function requestAsyncWithRetry(url, data = {}, method = 'POST', options = {}) {
    const retries = options.retries ?? 1;
    const timeout = options.timeout ?? 10000;
    const showSpinner = options.showSpinner ?? false;

    if (showSpinner) showLoadingSpinner();
    for (let attempt = 0; attempt <= retries; attempt++) {
        try {
            const controller = new AbortController();
            const id = setTimeout(() => controller.abort(), timeout);

            const res = await fetch(url, {
                method,
                headers: {
                    'Content-Type': 'application/json',
                    'X-Requested-With': 'XMLHttpRequest'
                },
                body: method.toUpperCase() !== 'GET' ? JSON.stringify(data) : null,
                signal: controller.signal
            });

            clearTimeout(id);

            if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);

            const html = await res.text();

            if (showSpinner) hideLoadingSpinner();

            if (html.includes("<!--SESSION_EXPIRED-->")) {
                handleSessionExpired();
                return null;
            }

            return html;

        } catch (err) {
            if (attempt >= retries) {
                if (showSpinner) hideLoadingSpinner();
                console.error("Request failed:", err);
                showToast("Request failed. Please try again.", "error");
                return null;
            }
        }
    }

    if (showSpinner) hideLoadingSpinner();
    return null;
}

function showLoadingSpinner() {
    document.body.classList.add('loading');
    document.querySelector('.spinner').style.display = 'block';
}
function hideLoadingSpinner() {
    document.body.classList.remove('loading');
    document.querySelector('.spinner').style.display = 'none';
}

function showToast(message, type = 'info') {
    alert(`[${type.toUpperCase()}] ${message}`); 
}
function handleSessionExpired() {
    window.location.href = "/Account/Login";
}
