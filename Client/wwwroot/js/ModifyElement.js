window.modifyElement = {
    addDrawerBackdropElement: function () {
        var element = document.getElementById("drawerBackdrop");

        if (!element.classList.length > 0) {
            element.className = "bg-gray-900/50 dark:bg-gray-900/80 fixed inset-0 z-30";
            element.setAttribute("drawer-backdrop", "");

            var elementAside = document.getElementById("sidebar-multi-level-sidebar");
            elementAside.className = "fixed top-0 left-0 z-40 w-64 h-screen transition-transform sm:translate-x-0 transform-none";
            elementAside.setAttribute("aria-modal", "true");
            elementAside.setAttribute("role", "dialog");
            elementAside.removeAttribute("aria-hidden");

            element.onclick = function () {
                // Fungsi ini akan dijalankan saat elemen di klik
                modifyElement.removeDrawerBackdropElement();
            };
        }
    },
    removeDrawerBackdropElement: function () {
        var element = document.getElementById("drawerBackdrop");
        if (element.classList.length > 0) {
            element.removeAttribute("class");
            element.removeAttribute("drawer-backdrop");
        }

        changeBodyClass("bg-stone-200")

        var elementAside = document.getElementById("sidebar-multi-level-sidebar");
        elementAside.className = "fixed top-0 left-0 z-40 w-64 h-screen transition-transform sm:translate-x-0 -translate-x-full";
        elementAside.removeAttribute("aria-modal");
        elementAside.removeAttribute("role");
        elementAside.setAttribute("aria-hidden", "true");

        if (window.blazorLocalStorage && typeof window.blazorLocalStorage.setItem === 'function') {
            window.blazorLocalStorage.setItem("_isActivateSideBar", "False");
        } else {
            console.error('Metode setItem tidak ditemukan.');
        }
    },
    addModalBackdropElement: function (id) {
        var element = document.getElementById("modalBackdrop");

        if (!element.classList.length > 0) {
            element.className = "bg-gray-900/50 dark:bg-gray-900/80 fixed inset-0 z-40";
            element.setAttribute("modal-backdrop", "");

            var elementAside = document.getElementById(id);
            elementAside.className = "overflow-y-auto overflow-x-hidden fixed top-0 right-0 left-0 z-50 justify-center items-center w-full md:inset-0 h-[calc(100%-1rem)] max-h-full flex";
            elementAside.setAttribute("aria-modal", "true");
            elementAside.setAttribute("role", "dialog");
            elementAside.removeAttribute("aria-hidden");
        }
    },
    removeModalBackdropElement: function (id) {
        var element = document.getElementById("modalBackdrop");
        if (element.classList.length > 0) {
            element.removeAttribute("class");
            element.removeAttribute("modal-backdrop");
        }

        changeBodyClass("bg-stone-200")

        var elementAside = document.getElementById(id);
        elementAside.className = "overflow-y-auto overflow-x-hidden fixed top-0 right-0 left-0 z-50 justify-center items-center w-full md:inset-0 h-[calc(100%-1rem)] max-h-full hidden";
        elementAside.removeAttribute("aria-modal");
        elementAside.removeAttribute("role");
        elementAside.setAttribute("aria-hidden", "true");

        if (window.blazorLocalStorage && typeof window.blazorLocalStorage.setItem === 'function') {
            window.blazorLocalStorage.setItem("_isActiveModal", "False");
        } else {
            console.error('Metode setItem tidak ditemukan.');
        }
    },
};