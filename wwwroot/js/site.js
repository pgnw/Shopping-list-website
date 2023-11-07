// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener('load', () => {
    try {
        //Add an event listener to the component specified to manage click events
        document.getElementById("btnTheme").addEventListener('click', () => {
            switchTheme();
        })
    }
    catch {
        console.log("tried to find btnTheme but could not")
    }
    
    
})
function fixModalSubmitBtn(actionTarget, postFunction ) {
    // Find the button on the modal.
    let submitButton = document.querySelector(`form[action='${actionTarget}']`);


    // Add an event listener to the button.
    submitButton.addEventListener('submit', async (e) => {
        // Prevent the button from carrying out it's regular function
        e.preventDefault();

        // Get the login information entered into the form.
        let loginInformation = {
            Email: e.target["Email"].value,
            Password: e.target["Password"].value
        };

        //Retrieve the anti forgery token from the form. This is in a hidden input field
        //called __RequestVerificationToken. This will be added to our fetch request headers later
        //to passs the controllers Anti-Forgery-Token check.
        //NOTE: This name has 2 underscores at the beginning.
        let token = $("input[name='__RequestVerificationToken']").val();

        let result = postFunction(token,loginInformation);

        console.log(result);


        //location.reload();
    })
}




/*    fixModalSubmitBtn('/Login/Login', (token, formData) => {
        let result = fetch("/Login/Login", {
            method: "POST",
            headers: {
                "content-type": "application/json",
                "RequestVerificationToken": token
            },
            body: JSON.stringify(formData)
        });

        return result;
    })

*/


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
