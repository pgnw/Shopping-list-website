
// This Javascript file is used to manage user actions such as logging in and signing up.

window.addEventListener('load', () => {
    document.getElementById("btnLogin").addEventListener('click', () => { showLogin(); });
    document.getElementById("btnSignup").addEventListener('click', () => { showSignup(); });

})

async function showLogin() {
    // Get the partial page
    let page = await fetch("/Login");
    // Get the html text from the page
    let htmlResult = await page.text();

    // Add the html text to the modal
    modalContent = document.getElementById("mContent");

    modalContent.innerHTML = htmlResult;

    //Get the login form
    let form = document.querySelector("form[action='/Login/Login']");
    $.validator.unobtrusive.parse(form);

    form.addEventListener('submit', async (e) => {
        // Prevent the button from carrying out it's regular function
        e.preventDefault();

        //Gets the form from the event details.
        let form = e.target;
        //Takes the form and converts it from HTML to a JQuery object that can be used for validation.
        let formResult = $(form);
        //Check if the form is not valid
        if (formResult.valid() == false) {
            //If it isn;t valid, return out of the method and don't do any more steps.
            return;
        }
        
        // Get the login information entered into the form.
        let loginInformation = {
            Email: e.target["Email"].value,
            Password: e.target["Password"].value
        };

        // Get the verification token so the ValidateAntiForgeryToken attribute in the controller doesn't stop the request
        let token = $("input[name='__RequestVerificationToken']").val();

        // Send the users details to the login controller endpoint so they can be logged in.
        let result = await fetch("/Login/Login", {
            method: "POST",
            headers: {
                "content-type": "application/json",
                "RequestVerificationToken": token
            },
            body: JSON.stringify(loginInformation)
        });
        if (result.status != 200) {
            alert("Login failed");
            return;
        }
        location.reload();

    })

    $("#m").modal("show");

}

async function showSignup() {
    // Get the partial page
    let result = await fetch("/Signup");
    // Get the html text from the page
    let htmlResult = await result.text();

    // Add the html text to the modal
    document.getElementById("mContent").innerHTML = htmlResult;

    // Get the signup form
    let form = document.querySelector("form[action='/Signup/Signup']");
    // Ensure that the data is validate.
    $.validator.unobtrusive.parse(form);

    form.addEventListener('submit', async (e) => {
        // Prevent the button from carrying out it's regular function
        e.preventDefault();

        // Get the login information entered into the form.
        let loginInformation = {
            Email: e.target["Email"].value,
            Password: e.target["Password"].value
        };

          // Get the verification token so the ValidateAntiForgeryToken attribute in the controller doesn't stop the request
        let token = $("input[name='__RequestVerificationToken']").val();

        // Send the users details to the signup controller endpoint to create a new account.
        let result = await fetch("/Signup/Signup", {
            method: "POST",
            headers: {
                "content-type": "application/json",
                "RequestVerificationToken": token
            },
            body: JSON.stringify(loginInformation)
        });

        // If the signup failed alert the user and return.
        if (result.status != 200) {
            alert("Signup failed, please make sure that the username is aleast 4 characters long and the password 8 characters");
            return;
        }

        await fetch("/Login/Login", {
            method: "POST",
            headers: {
                "content-type": "application/json",
                "RequestVerificationToken": token
            },
            body: JSON.stringify(loginInformation)
        });


        location.reload();


    })
    // Show the modal
    $("#m").modal("show");
}