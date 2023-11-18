// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener('load', () => {
    try {
        //Add an event listener to the component specified to manage click events
        document.getElementById("btnDark").addEventListener('click', () => {
            switchTheme("dark");
        })
        document.getElementById("btnLight").addEventListener('click', () => {
            switchTheme("light");
        })
    }
    catch {
        console.log("failed to add theme event listeners")
    }


})

/*
function fixModalSubmitBtn(actionTarget, postFunction) {
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

        let result = postFunction(token, loginInformation);

        console.log(result);


        //location.reload();
    })
}

*/


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


async function switchTheme(colour) {

    if (colour == "light") {

        //Send a post request to the settings controller to change the theme setting in the server
        let result = await fetch('/Settings/SetTheme', {
            method: "POST",
            headers: {
                "content-type": "application/json"
            },
            body: JSON.stringify({ Theme: "light" })
        });

        // Set the theme style link to the light theme
        document.getElementById("themeStyle").setAttribute('href', 'css/themes/light-theme.css');
    }
    else {

        //Send a post request to pur settings controller to change the theme setting in the server
        let result = await fetch('/Settings/SetTheme', {
            method: "POST",
            headers: {
                "content-type": "application/json"
            },
            body: JSON.stringify({ Theme: "dark" })
        });
        // Set the theme style link to the dark theme.
        document.getElementById("themeStyle").setAttribute('href', 'css/themes/dark-theme.css')
    }
}
