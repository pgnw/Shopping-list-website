window.addEventListener('load', () => {

    // Add the event listener to every add button on the page.
    try {
        let addBtns = document.querySelectorAll('#AddHome');

        addBtns.forEach((btn => btn.addEventListener('click', () => addItem2(btn.getAttribute('itemId')))));
    }
    catch {
        console.log("error setting item add button event handlers for home")
    }

});

async function addItem2(itemId) {
    let URL = "/ShoppingCart/AddItem";

    let fullURL = `${URL}?itemId=${itemId}`;

    // Get the verification token so the ValidateAntiForgeryToken attribute in the controller doesn't stop the request
    let token = $("input[name='__RequestVerificationToken']").val();

    // Tell the controller to add a item.
    await fetch(fullURL, {
        method: 'POST',
        headers: {
            "content-type": "application/json",
            "RequestVerificationToken": token
        }

    });
}



