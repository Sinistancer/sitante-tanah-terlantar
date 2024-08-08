window.cookieFunction = {
    deleteCookiesWithPartialName(partialName) {
        console.log(document.cookie);
        document.cookie.split(';').forEach(function (cookie) {
            let cookieName = cookie.split('=')[0].trim();
            console.log("test" + cookieName);
            console.log(document.cookie);
            if (cookieName.includes(partialName)) {
                document.cookie = cookieName + '=; Max-Age=-99999999;';
            }
        });
    }
}