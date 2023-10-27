// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener('load', () => {

    //Add an event listener to the component specified to manage click events
    document.getElementById("btnTheme").addEventListener('click', () => {
        switchTheme();
    })
})

async function switchTheme() {
    //Get the current theme setting from the local storage(if it has been set) of your PC and store it.
    let currentTheme = localStorage.getItem("Theme") || "Dark";
    //If the current theme has a value and it is equal to Dark mode
    if (currentTheme && currentTheme == "Dark") {

        localStorage.setItem("Theme", "Light")
        //Send a post request to pur settings controller to change the theme setting in the server
        let result = await fetch('api/Settings/SetTheme', {
            method: "POST",
            headers: {
                "content-type": "application/json"
            },
            body: JSON.stringify({ Theme: "Light" })
        });

        document.getElementById("themeStyle").setAttribute('href', 'css/themes/light-theme.css')
    }
    else if (currentTheme && currentTheme == "Light") {
        localStorage.setItem("Theme", "Dark")

        //Send a post request to pur settings controller to change the theme setting in the server
        let result = await fetch('api/Settings/SetTheme', {
            method: "POST",
            headers: {
                "content-type": "application/json"
            },
            body: JSON.stringify({ Theme: "Dark" })
        });

        document.getElementById("themeStyle").setAttribute('href', 'css/themes/dark-theme.css')
    }
}
