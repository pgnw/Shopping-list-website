// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener('load', () => {


    try {
        let deleteBtns = document.querySelectorAll('#cartDelete');

        deleteBtns.forEach((btn => btn.addEventListener('click', () => DeleteCart(btn.getAttribute('cartId')))));

    }
    catch {
        console.log("error setting delete button event handlers")
    }

    try {
        let deleteBtns = document.querySelectorAll('#cartSelect');

        deleteBtns.forEach((btn => btn.addEventListener('click', () => loadShoppingCartItems(btn.getAttribute('cartId')))));
    }
    catch {
        console.log("error adding cart select event")
    }



    document.getElementById("btnListCreate").addEventListener('click', () => {
        NewShoppingList();
    });
});



async function loadShoppingCartItems(cartId)
{

    let URL = "/ShoppingCart/GetCartContents";

    let fullURL = `${URL}?cartName=${cartId}`;

    // Get the verification token so the ValidateAntiForgeryToken attribute in the controller doesn't stop the request
    let token = $("input[name='__RequestVerificationToken']").val();

    // Tell the controller to create a new view containing all the items of the current cart.
    let cartItems = await fetch(fullURL, {
        method: 'POST',
        headers: {
            "content-type": "application/json",
            "RequestVerificationToken": token
        }

    });

    let cardHolder = document.getElementById("cardHolder");

    cardHolder.innerHTML = await cartItems.text();

            
}
    
async function NewShoppingList() {

    // Get the name of the shopping cart the user gave it.
    let listName = document.getElementById("newListName").value;

    let URL = "/ShoppingCart/MakeNewShoppingCart";
        
    let fullURL = `${URL}?cartName=${listName}`;

    // Get the verification token so the ValidateAntiForgeryToken attribute in the controller doesn't stop the request
    let token = $("input[name='__RequestVerificationToken']").val();

    // Tell the controller to add the new cart.
    await fetch(fullURL, {
        method: 'POST',
        headers: {
            "content-type": "application/json",
            "RequestVerificationToken": token
        }

    });

    location.reload();

}

async function DeleteCart(cartId) {

    console.log('deletebutton clicked')

    let URL = "/ShoppingCart/DeleteShoppingCart";

    let fullURL = `${URL}?cartId=${cartId}`;

    // Get the verification token so the ValidateAntiForgeryToken attribute in the controller doesn't stop the request
    let token = $("input[name='__RequestVerificationToken']").val();

    // Tell the controller to add the new cart.
    await fetch(fullURL, {
        method: 'POST',
        headers: {
            "content-type": "application/json",
            "RequestVerificationToken": token
        }

    });

    location.reload();
}

