/*
window.addEventListener('load', () => {

    var theme = fetch("/Settings/GetTheme");

    

    if (theme == null || theme == "light") {
        document.getElementById("themeStyle").setAttribute('href', 'css/themes/light-theme.css')
        console.log("Setting theme to light");
    }
    else {
        document.getElementById("themeStyle").setAttribute('href', 'css/themes/dark-theme.css')
        console.log("Setting theme to dark");
    }


})